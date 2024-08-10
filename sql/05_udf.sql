-- udf tests--
--USE Tests;
USE p2g4;
GO

DROP FUNCTION IF EXISTS dbo.ObterInformacaoUtilizador;
GO
DROP FUNCTION IF EXISTS dbo.ObterChatsDoUtilizador;
GO
DROP FUNCTION IF EXISTS dbo.ObterMensagensDoChat;
GO
DROP FUNCTION IF EXISTS dbo.ObterTodosOsProdutos;
GO
DROP FUNCTION IF EXISTS dbo.PesquisaProdutos;
GO
DROP FUNCTION IF EXISTS dbo.PesquisaCaracteristicas;
GO

CREATE FUNCTION dbo.ObterInformacaoUtilizador
(
    @NIF INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        NIF,
        Nome,
        Email,
        Hash,
        N_telemovel
    FROM 
        Utilizador
    WHERE 
        NIF = @NIF
);
GO


CREATE FUNCTION dbo.ObterChatsDoUtilizador
(
    @UtilizadorNIF INT
)
RETURNS @Chats TABLE
(
    Chat_A_NIF INT,
    Chat_B_NIF INT
)
AS
BEGIN
    -- Inserir os chats do utilizador na tabela de retorno
    INSERT INTO @Chats
    SELECT A_NIF, B_NIF
    FROM Chat
    WHERE A_NIF = @UtilizadorNIF OR B_NIF = @UtilizadorNIF;

    RETURN;
END;
GO
CREATE FUNCTION dbo.ObterMensagensDoChat
(
    @UtilizadorNIF INT,
    @Chat_NIF INT
)
RETURNS @Mensagens TABLE
(
    MensagemID INT,
    Chat_A_NIF INT,
    Chat_B_NIF INT,
    EnviadoPor INT,
    HoraEnviada DATETIME,
    Conteudo NVARCHAR(MAX)
)
AS
BEGIN
    -- Verificar se o usuário que chamou a função está envolvido no chat
    IF EXISTS (
        SELECT 1
        FROM Chat
        WHERE (A_NIF = @UtilizadorNIF AND B_NIF = @Chat_NIF) 
           OR (A_NIF = @Chat_NIF AND B_NIF = @UtilizadorNIF)
    )
    BEGIN
        -- Inserir as mensagens do chat na tabela de retorno
        INSERT INTO @Mensagens
        SELECT MensagemID, Chat_A_NIF, Chat_B_NIF, EnviadoPor, HoraEnviada, Conteudo
        FROM Mensagem
        WHERE (Chat_A_NIF = @UtilizadorNIF AND Chat_B_NIF = @Chat_NIF)
           OR (Chat_A_NIF = @Chat_NIF AND Chat_B_NIF = @UtilizadorNIF)
        ORDER BY HoraEnviada;
    END

    RETURN;
END;
GO
CREATE FUNCTION dbo.ObterTodosOsProdutos()
RETURNS @Produtos TABLE
(
    ProdutoID INT,
    VendedorNIF INT,
    Nome NVARCHAR(255),
    Preco DECIMAL(10, 2)
)
AS
BEGIN
    -- Inserir todos os produtos na tabela de retorno
    INSERT INTO @Produtos
    SELECT ProdutoID, VendedorNIF, Nome, Preco
    FROM Produto;

    RETURN;
END;
GO

CREATE FUNCTION dbo.PesquisaProdutos(
    @CaracteristicasValores NVARCHAR(MAX)
)
RETURNS TABLE
AS
RETURN
(
    WITH Caracteristicas AS (
        SELECT 
            LTRIM(RTRIM(SUBSTRING(value, 1, CHARINDEX(':', value) - 1))) AS NomeCaracteristica,
            LTRIM(RTRIM(SUBSTRING(value, CHARINDEX(':', value) + 1, LEN(value)))) AS ValorCaracteristica
        FROM 
            STRING_SPLIT(@CaracteristicasValores, ',')
        WHERE 
            CHARINDEX(':', value) > 0
    )
    SELECT p.ProdutoID, p.NomeProduto, p.Preco
    FROM vw_ProdutosCaracteristicas p
    JOIN Caracteristicas c ON p.NomeCaracteristica = c.NomeCaracteristica AND p.Valor = c.ValorCaracteristica
    GROUP BY p.ProdutoID, p.NomeProduto, p.Preco
    HAVING COUNT(DISTINCT p.CaracteristicaID) = (SELECT COUNT(*) FROM Caracteristicas)
);
GO
CREATE FUNCTION dbo.PesquisaCaracteristicas(
    @ProdutoID INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT 
        c.Nome AS NomeCaracteristica,
        pc.Valor AS ValorCaracteristica
    FROM 
        ProdutoCaracteristica pc
    JOIN 
        Caracteristica c ON pc.CaracteristicaID = c.CaracteristicaID
    WHERE 
        pc.ProdutoID = @ProdutoID
);
GO