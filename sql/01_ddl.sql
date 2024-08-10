--esta query->triggers->sp->insertions
/*
USE master;
GO

DECLARE @DatabaseName nvarchar(50)
SET @DatabaseName = N'Tests'

DECLARE @SQL varchar(max)

SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
FROM MASTER..SysProcesses
WHERE DBId = DB_ID(@DatabaseName) AND SPId <> @@SPId

--SELECT @SQL 
EXEC(@SQL)

DROP DATABASE Tests;
GO

CREATE DATABASE Tests;													
GO
*/
--USE Tests;
USE p2g4;
GO

DROP TABLE ProdutoCaracteristica;
DROP TABLE Caracteristica;
DROP TABLE Comentario;
DROP TABLE Produto;
DROP TABLE Mensagem;
DROP TABLE Chat;
DROP TABLE Vendedor;
DROP TABLE Comprador;
DROP TABLE Cliente;
DROP TABLE Funcionario;
DROP TABLE Utilizador;

-- STRUCTURE
CREATE TABLE Utilizador (
    NIF			INT				PRIMARY KEY,
	Nome		VARCHAR(255)	NOT NULL,
    Email		VARCHAR(255)	UNIQUE NOT NULL,
    Hash		VARCHAR(255)	NOT NULL,
    N_telemovel INT				UNIQUE NOT NULL,
	CONSTRAINT CHK_N_telemovel CHECK (
        (N_telemovel BETWEEN 910000000 AND 969999999) OR
        (N_telemovel BETWEEN 2000000000 AND 2999999999)
    ),
	
	CONSTRAINT CHK_NIF CHECK (NIF BETWEEN 100000000 AND 999999999),
	CONSTRAINT CHK_Email CHECK (
		Email LIKE '%@%.%'
    ),
	
);
Go
CREATE TABLE Cliente(
	NIF				INT PRIMARY KEY,
	Cl_ID			INT	IDENTITY(1, 1) UNIQUE NOT NULL,
    Rua			VARCHAR(255),
    Localidade	VARCHAR(255),
    Cod_Postal	VARCHAR(20),
	FOREIGN KEY (NIF) REFERENCES Utilizador(NIF) ON DELETE CASCADE, --ON UPDATE CASCADE, -- se eliminar Utilizador vai eliminar Cliente
);
CREATE TABLE Funcionario (
    NIF			INT PRIMARY KEY,
	Funcao		VARCHAR(15) DEFAULT 'gerente',
	F_ID		INT	IDENTITY(1, 1) UNIQUE NOT NULL,
    Salario	DECIMAL(10, 2) DEFAULT 800.00,
    FOREIGN KEY (NIF) REFERENCES Utilizador(NIF) ON DELETE CASCADE, --ON UPDATE CASCADE,
	CONSTRAINT CHK_Especialidade CHECK (Funcao IN('especialista', 'gerente')),
	CONSTRAINT CHK_Salario CHECK (Salario >= 800.00),
);
GO
CREATE TABLE Comprador (
    NIF				INT PRIMARY KEY,
    FOREIGN KEY (NIF) REFERENCES Cliente(NIF) ON DELETE CASCADE, --ON UPDATE CASCADE,
);
CREATE TABLE Vendedor (
    NIF				INT		PRIMARY KEY,
	N_likes		INT		DEFAULT(0),
	N_deslikes	INT		DEFAULT(0),
    FOREIGN KEY (NIF) REFERENCES Cliente(NIF) ON DELETE CASCADE, --ON UPDATE CASCADE,
);
GO
CREATE TABLE Chat (
    A_NIF	INT,
    B_NIF	INT,
    PRIMARY KEY (A_NIF, B_NIF),
    FOREIGN KEY (A_NIF) REFERENCES Utilizador(NIF), --ON DELETE SET NULL,
    FOREIGN KEY (B_NIF) REFERENCES Utilizador(NIF), --ON DELETE SET NULL,
);
GO
CREATE TABLE Mensagem (
    Chat_A_NIF	INT NOT NULL,
    Chat_B_NIF	INT NOT NULL,
    MensagemID	INT IDENTITY(1,1) NOT NULL,
    EnviadoPor	INT NOT NULL,
    HoraEnviada	DATETIME NOT NULL DEFAULT GETDATE(),
    Conteudo	NVARCHAR(MAX) NOT NULL,
    PRIMARY KEY (Chat_A_NIF, Chat_B_NIF, MensagemID), -- chave composta, entidade fraca com chave fraca ID, melhora a pesquisa pq os nifs estao indexados, caso as outras operacoes forem lentas simplificar a chave
    FOREIGN KEY (Chat_A_NIF, Chat_B_NIF) REFERENCES Chat(A_NIF, B_NIF), --ON DELETE SET NULL,
    FOREIGN KEY (EnviadoPor) REFERENCES Utilizador(NIF) --ON DELETE SET NULL
);
GO
CREATE TABLE Comentario (
    ComentarioID	INT IDENTITY(1,1) PRIMARY KEY,
    CompradorNIF	INT,
    VendedorNIF		INT NOT NULL,
    Conteudo		NVARCHAR(MAX) NOT NULL,
    DataComentario	DATETIME NOT NULL DEFAULT GETDATE(),
	N_likes		INT		DEFAULT(0),
	N_deslikes	INT		DEFAULT(0),
    FOREIGN KEY (CompradorNIF) REFERENCES Comprador(NIF), --ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (VendedorNIF) REFERENCES Vendedor(NIF) ON DELETE CASCADE,-- ON UPDATE CASCADE
);
GO
CREATE TABLE Produto (
    ProdutoID	INT IDENTITY(1,1) PRIMARY KEY,
    VendedorNIF INT NOT NULL,
    Nome		NVARCHAR(255) NOT NULL,
    Preco		DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (VendedorNIF) REFERENCES Vendedor(NIF) ON DELETE CASCADE, --ON UPDATE CASCADE,
	CONSTRAINT CHK_Preco CHECK (Preco > 0),
);
GO
CREATE TABLE Caracteristica ( 
    CaracteristicaID	INT IDENTITY(1,1) PRIMARY KEY,
    Nome				NVARCHAR(255) NOT NULL
);
GO
CREATE TABLE ProdutoCaracteristica (
    ProdutoID			INT NOT NULL,
    CaracteristicaID	INT NOT NULL,
    Valor				NVARCHAR(255) NOT NULL,
    PRIMARY KEY (ProdutoID, CaracteristicaID),
    FOREIGN KEY (ProdutoID)			REFERENCES Produto(ProdutoID), --ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (CaracteristicaID)	REFERENCES Caracteristica(CaracteristicaID) --ON DELETE CASCADE ON UPDATE CASCADE
);
GO
