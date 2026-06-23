# CadastroCarnes API

Backend do sistema CadastroCarnes.

API responsável pelas regras de negócio, persistência dos dados e disponibilização dos endpoints consumidos pelo frontend.

## Tecnologias utilizadas

- .NET
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger

## Funcionalidades

- Cadastro de carnes
- Cadastro de compradores
- Cadastro de localidades
- Cadastro de pedidos
- Endpoints REST
- Integração com banco de dados

---

# Como executar a API localmente

## Pré-requisitos

Instalar:

- .NET SDK
- SQL Server

Verificar instalação:

bash
dotnet --version


## Clonar o projeto

bash
git clone https://github.com/thomaskhris-hub/CadastroCarnesApi.git


Entrar na pasta:

bash
cd CadastroCarnesApi


Restaurar dependências:

bash
dotnet restore


## Configuração do banco de dados

Configurar a conexão no arquivo:


CadastroCarnes.Api/appsettings.json


Exemplo:

json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CadastroCarnes;Trusted_Connection=True;TrustServerCertificate=True"
  }
}


## Executar a API

Na pasta raiz do projeto:

bash
dotnet run --project CadastroCarnes.Api


A API será iniciada no endereço informado pelo terminal.

## Swagger

A documentação dos endpoints estará disponível em:


https://localhost:xxxx/swagger


