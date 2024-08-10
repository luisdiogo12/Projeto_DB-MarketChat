---------------------------------------------------------------------------------------------------------------------
-- Triggers Tests ---------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------
--USE Tests;
USE p2g4;
GO

/*
DROP TRIGGER IF EXISTS trg_Cliente_NotFuncionario;
DROP TRIGGER IF EXISTS trg_Funcionario_NotCliente;
DROP TRIGGER IF EXISTS trg_AfterDeleteVendedor;
DROP TRIGGER IF EXISTS trg_AfterDeleteComprador;
DROP TRIGGER IF EXISTS trg_AfterDeleteFuncionario;
DROP TRIGGER IF EXISTS trg_AfterDeleteCliente;
DROP TRIGGER IF EXISTS trg_VerificarChat;
DROP TRIGGER IF EXISTS trg_VerificarMensagem;
DROP TRIGGER IF EXISTS trg_VerificarVendedorDoProduto;
*/
-- em vez de (sql nao deixa): ALTER TABLE Cliente ADD CONSTRAINT CHK_Cliente_NotFuncionario CHECK (NIF NOT IN (SELECT NIF FROM Funcionario)); -- se j� for funcionario nao deixa ser cliente
CREATE TRIGGER trg_Cliente_NotFuncionario
ON Cliente
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Funcionario f ON i.NIF = f.NIF
    )
    BEGIN
        RAISERROR('Um Cliente nao pode ser um Funcionario.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    INSERT INTO Cliente (NIF)
    SELECT NIF FROM inserted;
END
GO

-- em vez de (sql nao deixa): ALTER TABLE Funcionario ADD CONSTRAINT CHK_Funcionario_NotCliente CHECK (NIF NOT IN (SELECT NIF FROM Cliente)); -- se j� for cliente nao deixa ser funcionario
CREATE TRIGGER trg_Funcionario_NotCliente
ON Funcionario
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Cliente c ON i.NIF = c.NIF
    )
    BEGIN
        RAISERROR('Um Funcionario nao pode ser um Cliente.', 16, 1);
        ROLLBACK TRANSACTION;
        RETURN;
    END

    INSERT INTO Funcionario (NIF)
    SELECT NIF FROM inserted;
END
GO

CREATE TRIGGER trg_AfterDeleteVendedor
ON Vendedor
AFTER DELETE
AS
BEGIN
    DECLARE @NIF INT
    SELECT @NIF = NIF FROM deleted
    DELETE FROM Utilizador WHERE NIF = @NIF -- apenas é preciso eliminar no utilizador que elimina as outras dependencias todas devido ao cascade
END
GO

CREATE TRIGGER trg_AfterDeleteComprador
ON Comprador
AFTER DELETE
AS
BEGIN
    DECLARE @NIF INT
    SELECT @NIF = NIF FROM deleted
    DELETE FROM Utilizador WHERE NIF = @NIF
END
GO

CREATE TRIGGER trg_AfterDeleteFuncionario
ON Funcionario
AFTER DELETE
AS
BEGIN
    DECLARE @NIF INT
    DELETE FROM Utilizador WHERE NIF = @NIF
END
GO

CREATE TRIGGER trg_AfterDeleteCliente
ON Cliente
AFTER DELETE
AS
BEGIN
    DECLARE @NIF INT
    SELECT @NIF = NIF FROM deleted
    DELETE FROM Utilizador WHERE NIF = @NIF
END
GO

-- apenas permite criar chats entre comprador e vendedor e entre cliente e funcion�rio
CREATE TRIGGER trg_VerificarChat
ON Chat
INSTEAD OF INSERT, UPDATE
AS
BEGIN
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @A_NIF INT;
    DECLARE @B_NIF INT;

    -- Loop para verificar cada linha a ser inserida ou atualizada
    DECLARE Cur CURSOR FOR
    SELECT A_NIF, B_NIF FROM inserted;

    OPEN Cur;
    FETCH NEXT FROM Cur INTO @A_NIF, @B_NIF;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Verificar se A_NIF e B_NIF sao diferentes
        IF @A_NIF = @B_NIF
        BEGIN
            SET @ErrorMessage = 'A_NIF n�o pode ser igual a B_NIF.';
            RAISERROR (@ErrorMessage, 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        -- Verificar combina��es v�lidas
        IF NOT (
            (EXISTS (SELECT 1 FROM Comprador WHERE Comprador.NIF = @A_NIF) AND  -- s� o comprador pode iniciar o chat
             EXISTS (SELECT 1 FROM Vendedor WHERE Vendedor.NIF = @B_NIF)) OR
            (EXISTS (SELECT 1 FROM Cliente WHERE Cliente.NIF = @A_NIF) AND      -- s� o cliente pode iniciar o chat
             EXISTS (SELECT 1 FROM Funcionario WHERE Funcionario.NIF = @B_NIF))
        )
        BEGIN
            SET @ErrorMessage = 'Um chat deve ser entre um Comprador e um Vendedor, ou entre um Cliente (Comprador/Vendedor) e um Funcionario. A_NIF: ' 
                                + CAST(@A_NIF AS NVARCHAR(50)) + ', B_NIF: ' + CAST(@B_NIF AS NVARCHAR(50));            
            RAISERROR (@ErrorMessage, 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        FETCH NEXT FROM Cur INTO @A_NIF, @B_NIF;
    END;

    CLOSE Cur;
    DEALLOCATE Cur;

    -- Inserir os dados se n�o houver erros
    INSERT INTO Chat (A_NIF, B_NIF)
    SELECT A_NIF, B_NIF
    FROM inserted;
END;
GO

-- apenas permite criar mensagens entre os nifas do chat
CREATE TRIGGER trg_VerificarMensagem
ON Mensagem
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @ErrorMessage NVARCHAR(4000);
    DECLARE @Chat_A_NIF INT;
    DECLARE @Chat_B_NIF INT;
    DECLARE @EnviadoPor INT;
    DECLARE @HoraEnviada DATETIME;
    DECLARE @Conteudo NVARCHAR(MAX);

    -- Loop para verificar cada linha a ser inserida
    DECLARE Cur CURSOR FOR
    SELECT Chat_A_NIF, Chat_B_NIF, EnviadoPor, HoraEnviada, Conteudo FROM inserted;

    OPEN Cur;
    FETCH NEXT FROM Cur INTO @Chat_A_NIF, @Chat_B_NIF, @EnviadoPor, @HoraEnviada, @Conteudo;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Verificar se EnviadoPor � um dos utilizadores do chat
        IF NOT (@EnviadoPor = @Chat_A_NIF OR @EnviadoPor = @Chat_B_NIF)
        BEGIN
            SET @ErrorMessage = 'A mensagem deve ser enviada por um dos utilizadores do chat. EnviadoPor: ' 
                                + CAST(@EnviadoPor AS NVARCHAR(50)) + ', Chat_A_NIF: ' + CAST(@Chat_A_NIF AS NVARCHAR(50)) 
                                + ', Chat_B_NIF: ' + CAST(@Chat_B_NIF AS NVARCHAR(50));            
            RAISERROR (@ErrorMessage, 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        FETCH NEXT FROM Cur INTO @Chat_A_NIF, @Chat_B_NIF, @EnviadoPor, @HoraEnviada, @Conteudo;
    END;

    CLOSE Cur;
    DEALLOCATE Cur;

    -- Inserir os dados se n�o houver erros
    INSERT INTO Mensagem (Chat_A_NIF, Chat_B_NIF, EnviadoPor, HoraEnviada, Conteudo)
    SELECT Chat_A_NIF, Chat_B_NIF, EnviadoPor, HoraEnviada, Conteudo
    FROM inserted;
END;
GO
CREATE TRIGGER trg_VerificarVendedorDoProduto
ON Produto
INSTEAD OF INSERT
AS
BEGIN
    DECLARE @VendedorNIF INT;
    DECLARE @Nome NVARCHAR(255);
    DECLARE @Preco DECIMAL(10, 2);
    DECLARE @ErrorMessage NVARCHAR(4000);

    -- Cursor para verificar cada linha a ser inserida
    DECLARE Cur CURSOR FOR
    SELECT VendedorNIF, Nome, Preco FROM inserted;

    OPEN Cur;
    FETCH NEXT FROM Cur INTO @VendedorNIF, @Nome, @Preco;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Verificar se o VendedorNIF existe na tabela Vendedor
        IF NOT EXISTS (SELECT 1 FROM Vendedor WHERE NIF = @VendedorNIF)
        BEGIN
            SET @ErrorMessage = 'O NIF do vendedor fornecido n�o existe na tabela Vendedor. VendedorNIF: ' + CAST(@VendedorNIF AS NVARCHAR(50));
            RAISERROR (@ErrorMessage, 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END;

        FETCH NEXT FROM Cur INTO @VendedorNIF, @Nome, @Preco;
    END;

    CLOSE Cur;
    DEALLOCATE Cur;

    -- Inserir os dados se n�o houver erros
    INSERT INTO Produto (VendedorNIF, Nome, Preco)
    SELECT VendedorNIF, Nome, Preco
    FROM inserted;
END;
GO