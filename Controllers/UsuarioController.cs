using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using cha3.Models;
using cha3.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cha3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ConfiguracaoSingleton _configuracaoSingleton;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _configuracaoSingleton = ConfiguracaoSingleton.Instancia;
        }

        /// <summary>
        /// Obtém todos os usuários.
        /// </summary>
        /// <returns>Uma lista de usuários.</returns>
        /// <response code="200">Retorna a lista de usuários.</response>
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário.</param>
        /// <returns>O usuário com o ID especificado.</returns>
        /// <response code="200">Retorna o usuário com o ID especificado.</response>
        /// <response code="404">Se o usuário não for encontrado.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="usuarioModel">Modelo do usuário a ser cadastrado.</param>
        /// <returns>O usuário cadastrado.</returns>
        /// <response code="201">Retorna o usuário cadastrado.</response>
        /// <response code="400">Se o modelo do usuário não for válido.</response>
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            if (usuarioModel == null)
            {
                return BadRequest("O modelo do usuário não pode ser nulo.");
            }

            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return CreatedAtAction(nameof(BuscarPorId), new { id = usuario.Id }, usuario);
        }

        /// <summary>
        /// Atualiza um usuário existente.
        /// </summary>
        /// <param name="id">ID do usuário a ser atualizado.</param>
        /// <param name="usuarioModel">Modelo atualizado do usuário.</param>
        /// <returns>O usuário atualizado.</returns>
        /// <response code="200">Retorna o usuário atualizado.</response>
        /// <response code="400">Se o modelo do usuário não for válido ou se o ID não coincidir.</response>
        /// <response code="404">Se o usuário não for encontrado.</response>
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar(int id, [FromBody] UsuarioModel usuarioModel)
        {
            if (usuarioModel == null || id != usuarioModel.Id)
            {
                return BadRequest("Modelo do usuário inválido ou ID não coincide.");
            }

            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        /// <summary>
        /// Remove um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário a ser removido.</param>
        /// <returns>Status da remoção.</returns>
        /// <response code="200">Retorna verdadeiro se a remoção foi bem-sucedida.</response>
        /// <response code="404">Se o usuário não for encontrado.</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            if (!apagado)
            {
                return NotFound();
            }
            return Ok(apagado);
        }

        /// <summary>
        /// Obtém a configuração atual.
        /// </summary>
        /// <returns>A configuração atual.</returns>
        /// <response code="200">Retorna a configuração atual.</response>
        [HttpGet("configuracao")]
        public ActionResult<string> GetConfiguracao()
        {
            return Ok(_configuracaoSingleton.Configuracao);
        }

        /// <summary>
        /// Atualiza a configuração.
        /// </summary>
        /// <param name="novaConfiguracao">Nova configuração a ser definida.</param>
        /// <response code="204">Configuração atualizada com sucesso.</response>
        /// <response code="400">Se a nova configuração for inválida.</response>
        [HttpPost("configuracao")]
        public IActionResult SetConfiguracao([FromBody] string novaConfiguracao)
        {
            if (string.IsNullOrWhiteSpace(novaConfiguracao))
            {
                return BadRequest("A nova configuração não pode ser vazia.");
            }

            _configuracaoSingleton.AtualizarConfiguracao(novaConfiguracao);
            return NoContent();
        }
    }
}


