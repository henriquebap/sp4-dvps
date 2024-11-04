namespace cha3.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }        
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public int? UsuarioId { get; set; } 

        public virtual UsuarioModel Usuario { get; set; }

    }
}
