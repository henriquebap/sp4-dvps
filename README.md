# API Challenge

## Descrição
Esta é uma API desenvolvida em ASP.NET Core Web API que permite a gestão de usuários. Ela segue princípios de arquitetura de software e design patterns, e inclui técnicas de documentação, testes e integração com o banco de dados Oracle.

## Arquitetura
A API foi implementada utilizando uma arquitetura monolítica. Esta escolha foi feita para simplificar o desenvolvimento e a manutenção, dado que o projeto é de escopo reduzido e não requer a complexidade de uma arquitetura de microservices. 

## Design Patterns
- **Singleton**: Foi implementado o padrão Singleton na classe `ConfiguracaoSingleton` para gerenciar configurações de forma global e garantir que apenas uma instância da configuração exista durante a execução da aplicação.

## Endpoints

### Buscar Todos os Usuários
- **Método:** `GET`
- **Rota:** `/api/usuario`
- **Descrição:** Obtém todos os usuários cadastrados.
- **Respostas:**
  - `200 OK`: Retorna a lista de usuários.

### Buscar Usuário por ID
- **Método:** `GET`
- **Rota:** `/api/usuario/{id}`
- **Descrição:** Obtém um usuário pelo ID.
- **Parâmetros:**
  - `id` (int): ID do usuário.
- **Respostas:**
  - `200 OK`: Retorna o usuário com o ID especificado.
  - `404 Not Found`: Se o usuário não for encontrado.

### Cadastrar Novo Usuário
- **Método:** `POST`
- **Rota:** `/api/usuario`
- **Descrição:** Cadastra um novo usuário.
- **Corpo da Requisição:**
  - `UsuarioModel`: Modelo do usuário a ser cadastrado.
- **Respostas:**
  - `201 Created`: Retorna o usuário cadastrado.
  - `400 Bad Request`: Se o modelo do usuário não for válido.

### Atualizar Usuário
- **Método:** `PUT`
- **Rota:** `/api/usuario/{id}`
- **Descrição:** Atualiza um usuário existente.
- **Parâmetros:**
  - `id` (int): ID do usuário a ser atualizado.
- **Corpo da Requisição:**
  - `UsuarioModel`: Modelo atualizado do usuário.
- **Respostas:**
  - `200 OK`: Retorna o usuário atualizado.

### Apagar Usuário
- **Método:** `DELETE`
- **Rota:** `/api/usuario/{id}`
- **Descrição:** Remove um usuário pelo ID.
- **Parâmetros:**
  - `id` (int): ID do usuário a ser removido.
- **Respostas:**
  - `200 OK`: Confirmação de que o usuário foi apagado.

### Obter Configuração Atual
- **Método:** `GET`
- **Rota:** `/api/usuario/configuracao`
- **Descrição:** Obtém a configuração atual.
- **Respostas:**
  - `200 OK`: Retorna a configuração atual.

### Atualizar Configuração
- **Método:** `POST`
- **Rota:** `/api/usuario/configuracao`
- **Descrição:** Atualiza a configuração.
- **Corpo da Requisição:**
  - `string`: Nova configuração a ser definida.
- **Respostas:**
  - `204 No Content`: Configuração atualizada com sucesso.
  - `400 Bad Request`: Se a nova configuração for inválida.

## Configuração do Ambiente
1. **Banco de Dados**: A API está configurada para usar um banco de dados Oracle. Certifique-se de ter o banco de dados Oracle acessível e as credenciais corretas no arquivo `appsettings.json`.

2. **Instalação de Dependências**: Execute o comando abaixo para restaurar as dependências do projeto:
   ```bash
   dotnet restore

## Criação do Banco de Dados: Execute as migrações para criar o banco de dados e suas tabelas:
1. `dotnet ef database update`
2. `dotnet run`

## Integrantes 
RM98469  - Pedro Duarte Farias 
RM98413 - Mateus Castro
RM551322 - Gabriel Caverzan 
RM551582 - Leonardo Valencio Dourado 
RM97796  - Henrique Oliveira Baptista

