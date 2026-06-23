-- ==========================================
-- CRIAÇÃO DO BANCO
-- ==========================================

IF NOT EXISTS (
    SELECT *
    FROM sys.databases
    WHERE name = 'CadastroCarnesDb'
)
BEGIN
    CREATE DATABASE CadastroCarnesDb;
END
GO

USE CadastroCarnesDb;
GO

-- ==========================================
-- ESTADOS
-- ==========================================

CREATE TABLE Estados
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nome NVARCHAR(100) NOT NULL,
    UF NVARCHAR(2) NOT NULL,

    CONSTRAINT PK_Estados
        PRIMARY KEY (Id)
);
GO

-- ==========================================
-- CIDADES
-- ==========================================

CREATE TABLE Cidades
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nome NVARCHAR(100) NOT NULL,
    EstadoId INT NOT NULL,

    CONSTRAINT PK_Cidades
        PRIMARY KEY (Id),

    CONSTRAINT FK_Cidades_Estados
        FOREIGN KEY (EstadoId)
        REFERENCES Estados(Id)
);
GO

-- ==========================================
-- COMPRADORES
-- ==========================================

CREATE TABLE Compradores
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nome NVARCHAR(150) NOT NULL,
    Documento NVARCHAR(20) NOT NULL,
    CidadeId INT NOT NULL,

    CONSTRAINT PK_Compradores
        PRIMARY KEY (Id),

    CONSTRAINT FK_Compradores_Cidades
        FOREIGN KEY (CidadeId)
        REFERENCES Cidades(Id)
);
GO

-- ==========================================
-- CARNES
-- ==========================================

CREATE TABLE Carnes
(
    Id INT IDENTITY(1,1) NOT NULL,
    Descricao NVARCHAR(150) NOT NULL,
    Origem INT NOT NULL,

    CONSTRAINT PK_Carnes
        PRIMARY KEY (Id)
);
GO

-- ==========================================
-- PEDIDOS
-- ==========================================

CREATE TABLE Pedidos
(
    Id INT IDENTITY(1,1) NOT NULL,
    DataPedido DATETIME2 NOT NULL,
    CompradorId INT NOT NULL,

    CONSTRAINT PK_Pedidos
        PRIMARY KEY (Id),

    CONSTRAINT FK_Pedidos_Compradores
        FOREIGN KEY (CompradorId)
        REFERENCES Compradores(Id)
);
GO

-- ==========================================
-- PEDIDO ITENS
-- ==========================================

CREATE TABLE PedidoItens
(
    Id INT IDENTITY(1,1) NOT NULL,
    PedidoId INT NOT NULL,
    CarneId INT NOT NULL,
    Preco DECIMAL(18,2) NOT NULL,
    Moeda INT NOT NULL,

    CONSTRAINT PK_PedidoItens
        PRIMARY KEY (Id),

    CONSTRAINT FK_PedidoItens_Pedidos
        FOREIGN KEY (PedidoId)
        REFERENCES Pedidos(Id),

    CONSTRAINT FK_PedidoItens_Carnes
        FOREIGN KEY (CarneId)
        REFERENCES Carnes(Id)
);
GO

-- ==========================================
-- ESTADOS INICIAIS
-- ==========================================

INSERT INTO Estados (Nome, UF)
VALUES
('Minas Gerais', 'MG'),
('São Paulo', 'SP'),
('Rio de Janeiro', 'RJ');
GO

-- ==========================================
-- CIDADES INICIAIS
-- ==========================================

INSERT INTO Cidades (Nome, EstadoId)
VALUES
('Sete Lagoas', 1),
('Belo Horizonte', 1),
('São Paulo', 2),
('Campinas', 2),
('Rio de Janeiro', 3);
GO

-- ==========================================
-- CARNES
-- ==========================================

INSERT INTO Carnes
(
    Descricao,
    Origem
)
VALUES
('Picanha', 0),
('Alcatra', 0),
('Costela Bovina', 1),
('Fraldinha', 0),
('Contra Filé', 1);
GO

-- ==========================================
-- COMPRADORES
-- ==========================================

INSERT INTO Compradores
(
    Nome,
    Documento,
    CidadeId
)
VALUES
('João da Silva', '12345678900', 1),
('Maria Oliveira', '98765432100', 2),
('Carlos Souza', '45678912300', 3);
GO

-- ==========================================
-- CONSULTAS DE VERIFICAÇÃO
-- ==========================================

SELECT * FROM Estados;
SELECT * FROM Cidades;
SELECT * FROM Compradores;
SELECT * FROM Carnes;
SELECT * FROM Pedidos;
SELECT * FROM PedidoItens;
GO