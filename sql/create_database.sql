-- Criação do banco de dados
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

-- Criação da tabela Endereco
CREATE TABLE Endereco (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    ClienteID INT NOT NULL,
    Rua VARCHAR(100) NOT NULL,
    Numero VARCHAR(10) NOT NULL,
    Complemento VARCHAR(50),
    Bairro VARCHAR(50) NOT NULL,
    Cidade VARCHAR(50) NOT NULL,
    Estado VARCHAR(2) NOT NULL,
    CEP VARCHAR(8) NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Cliente(ID)
);
