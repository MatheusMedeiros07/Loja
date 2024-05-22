# Gestão de Cadastro de Clientes

Esta é uma aplicação para gestão de cadastro de clientes, desenvolvida utilizando C# e ASP.NET. A aplicação permite cadastrar, editar, deletar e visualizar informações de clientes.

## Funcionalidades

- Adicionar novos clientes
- Editar informações de clientes existentes
- Excluir clientes
- Visualizar detalhes dos clientes
- Filtrar clientes por nome, e-mail, telefone, data de cadastro e status de bloqueio

## Tecnologias Utilizadas

- C#
- ASP.NET
- Entity Framework Core
- MySQL
- Bootstrap
- JQuery

## Estrutura do Projeto

- **Controllers**: Contém os controladores da aplicação
- **Models**: Contém as classes de modelo da aplicação
- **Views**: Contém as views da aplicação (arquivos .cshtml)
- **SQL**: Contém o script SQL para criação do banco de dados e tabelas

## Requisitos

- .NET 6.0 SDK ou superior
- MySQL Server

## Configuração do Ambiente

1. Clone o repositório:
    ```bash
    git clone https://github.com/seu-usuario/sua-aplicacao.git
    cd sua-aplicacao
    ```

2. Configure a string de conexão com o banco de dados no arquivo `appsettings.json`:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=GestaoClientes;User Id=root;Password=sua-senha;"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

3. Crie o banco de dados e as tabelas utilizando o script SQL fornecido. O script está localizado na pasta `SQL` na raiz do projeto.

## Script de Criação do Banco de Dados e Tabelas

Navegue até a pasta `SQL` e execute o script `create_database.sql` no seu MySQL Server. Você pode usar o MySQL Workbench ou qualquer outro cliente MySQL para executar o script.

### Script para criação do banco de dados que está na pasta SQL na raiz do projeto (`create_database.sql`):

```sql
-- Uso do banco de dados
CREATE DATABASE loja;

-- Seleciona o banco de dados para uso
USE loja;

-- Criação da tabela Cliente
CREATE TABLE Cliente (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(150) NOT NULL,
    CPF_CNPJ VARCHAR(14) NOT NULL UNIQUE,
    DataNascimento DATE,
    Email VARCHAR(150) NOT NULL UNIQUE,
    Telefone VARCHAR(15) NOT NULL,
    DataCadastro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    TipoPessoa VARCHAR(10) NOT NULL,
    InscricaoEstadual VARCHAR(15),  -- Ajuste para permitir até 12 caracteres
    Isento BOOLEAN NOT NULL DEFAULT TRUE,
    Genero VARCHAR(10),
    Bloqueado BOOLEAN NOT NULL DEFAULT FALSE,
    Senha VARCHAR(15) NOT NULL,
    CHECK (TipoPessoa IN ('Fisica', 'Juridica')),
    CHECK (Genero IN ('Feminino', 'Masculino', 'Outro') OR Genero IS NULL)
);

### Script para Inserção de dados para teste que está na pasta SQL na raiz do projeto (`INSERT de dados ficticios para testes`):

