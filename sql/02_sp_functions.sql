--Tests SP
--USE Tests;
USE p2g4;
GO
/*
DROP PROCEDURE InsertUtilizadorAsCliente; --sp_InsertCliente InsertUtilizadorAsCliente
DROP PROCEDURE UpdateCompradorToCompradorEVendedor; --sp_UpdateComprador UpdateCompradorToCompradorEVendedor
DROP PROCEDURE InsertUtilizadorAsFuncionario; --sp_InsertFuncionario InsertUtilizadorAsFuncionario
DROP PROCEDURE CreateChat; --sp_CreateChat CreateChat
DROP PROCEDURE EnviarMensagem; --sp_SendMensagem EnviarMensagem
DROP PROCEDURE InserirProduto; --sp_InsertProduto InserirProduto
DROP PROCEDURE InserirComentario; --sp_InsertComentario InserirComentario
GO
*/

DROP PROCEDURE sp_InsertCliente; --sp_InsertCliente InsertUtilizadorAsCliente
DROP PROCEDURE sp_UpdateComprador; --sp_UpdateComprador UpdateCompradorToCompradorEVendedor
DROP PROCEDURE sp_InsertFuncionario; --sp_InsertFuncionario InsertUtilizadorAsFuncionario
DROP PROCEDURE sp_CreateChat; --sp_CreateChat CreateChat
DROP PROCEDURE sp_SendMensagem; --sp_SendMensagem EnviarMensagem
DROP PROCEDURE sp_InsertProduto; --sp_InsertProduto InserirProduto
DROP PROCEDURE sp_InsertComentario; --sp_InsertComentario InserirComentario
DROP PROCEDURE sp_AdicionarCaracteristicaProduto;
GO


CREATE PROCEDURE sp_InsertCliente
--exemplo: EXEC sp_InsertCliente @NIF = 1, @Nome = 'John Doe', @Email = 'johndoe@example.com', @Hash = 'hash_value', @N_telemovel = 123456789, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 1, @IsVendedor = 0;
    @NIF INT,
    @Nome VARCHAR(255),
    @Email VARCHAR(255),
    @Hash VARCHAR(255),
    @N_telemovel INT,
    @Rua VARCHAR(255),
    @Localidade VARCHAR(255),
    @Cod_Postal VARCHAR(20),
    @IsComprador BIT,
    @IsVendedor BIT
AS
BEGIN
    IF @IsComprador = 0 AND @IsVendedor = 0
    BEGIN
        RAISERROR ('Um Cliente deve ser Comprador ou Vendedor ou ambos', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Inserir na tabela Utilizador
        INSERT INTO Utilizador (NIF, Nome, Email, Hash, N_telemovel)
        VALUES (@NIF, @Nome, @Email, @Hash, @N_telemovel);

        -- Inserir na tabela Cliente
        INSERT INTO Cliente (NIF, Rua, Localidade, Cod_Postal)
        VALUES (@NIF, @Rua, @Localidade, @Cod_Postal);

        -- Inserir na tabela Comprador se @IsComprador for verdadeiro
        IF @IsComprador = 1
        BEGIN
            INSERT INTO Comprador (NIF)
            VALUES (@NIF);
        END

        -- Inserir na tabela Vendedor se @IsVendedor for verdadeiro
        IF @IsVendedor = 1
        BEGIN
            INSERT INTO Vendedor (NIF)
            VALUES (@NIF);
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

CREATE PROCEDURE sp_UpdateComprador
-- exemplo: EXEC sp_UpdateComprador @NIF = 1;
    @NIF INT
AS
BEGIN
    -- Verificar se o NIF é de um cliente existente
    IF NOT EXISTS (SELECT 1 FROM Cliente WHERE NIF = @NIF)
    BEGIN
        RAISERROR ('NIF não encontrado na tabela Cliente', 16, 1);
        RETURN;
    END

    -- Verificar se o NIF é de um comprador existente
    IF NOT EXISTS (SELECT 1 FROM Comprador WHERE NIF = @NIF)
    BEGIN
        RAISERROR ('NIF não encontrado na tabela Comprador', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Inserir na tabela Vendedor se ainda não for vendedor
        IF NOT EXISTS (SELECT 1 FROM Vendedor WHERE NIF = @NIF)
        BEGIN
            INSERT INTO Vendedor (NIF)
            VALUES (@NIF);
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
CREATE PROCEDURE sp_InsertFuncionario
--exemplo: EXEC sp_InsertFuncionario @NIF = 4, @Nome = 'Bob Brown', @Email = 'bobbrown@example.com', @Hash = 'hash_value', @N_telemovel = 987654321, @Salario = 2000.00;
    @GerenteNIF INT,
    @NIF INT,
    @Nome VARCHAR(255),
    @Email VARCHAR(255),
    @Hash VARCHAR(255),
    @N_telemovel INT,
    @Funcao VARCHAR(15) = NULL, -- valor default
	@Salario DECIMAL(10, 2)
AS
BEGIN
	SET NOCOUNT ON;
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Verificar se o usuário que está tentando adicionar é um gerente
        IF EXISTS (SELECT 1 FROM Funcionario WHERE NIF = @GerenteNIF AND Funcao = 'gerente')
        BEGIN
            -- Inserir na tabela Utilizador
            INSERT INTO Utilizador (NIF, Nome, Email, Hash, N_telemovel)
            VALUES (@NIF, @Nome, @Email, @Hash, @N_telemovel);
            -- Inserir na tabela Funcionario
            INSERT INTO Funcionario (NIF, Funcao, Salario)
            VALUES (@NIF, @Funcao, @Salario);

            COMMIT TRANSACTION;
        END
        ELSE
        BEGIN
            -- Se não for gerente, lançar um erro e reverter a transação
            RAISERROR('Apenas gerentes podem adicionar novos funcionários.', 16, 1);
            ROLLBACK TRANSACTION;
        END
    END TRY
     BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END
        -- Re-lançar o erro capturado
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        THROW @ErrorMessage, @ErrorSeverity, @ErrorState;
    END CATCH
END;
GO

---------------------------------------------------------------------------------------------------------------------
---------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE sp_CreateChat
-- exemplo: EXEC sp_CreateChat @A_NIF = 1, @B_NIF = 2;
    @A_NIF INT,
    @B_NIF INT
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Tentar inserir na tabela Chat
        INSERT INTO Chat (A_NIF, B_NIF)
        VALUES (@A_NIF, @B_NIF);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
CREATE PROCEDURE sp_SendMensagem
    @Para INT,
    @EnviadoPor INT,
    @Conteudo NVARCHAR(MAX)
AS
BEGIN
    DECLARE @Chat_A_NIF INT;
    DECLARE @Chat_B_NIF INT;

    -- Buscar o chat existente
    SELECT @Chat_A_NIF = A_NIF, @Chat_B_NIF = B_NIF
    FROM Chat
    WHERE (A_NIF = @Para AND B_NIF = @EnviadoPor)
       OR (A_NIF = @EnviadoPor AND B_NIF = @Para);

    -- Verificar se o chat foi encontrado
    IF @Chat_A_NIF IS NULL OR @Chat_B_NIF IS NULL
    BEGIN
        RAISERROR('Chat não encontrado entre os NIFs fornecidos.', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Inserir a mensagem na tabela Mensagem
        INSERT INTO Mensagem (Chat_A_NIF, Chat_B_NIF, EnviadoPor, HoraEnviada, Conteudo)
        VALUES (@Chat_A_NIF, @Chat_B_NIF, @EnviadoPor, GETDATE(), @Conteudo);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
-- produto
CREATE PROCEDURE sp_InsertProduto
    @VendedorNIF INT,
    @Nome NVARCHAR(255),
    @Preco DECIMAL(10, 2),
	@ProdutoID INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Verificar se o VendedorNIF existe na tabela Vendedor
        IF NOT EXISTS (SELECT 1 FROM Vendedor WHERE NIF = @VendedorNIF)
        BEGIN
            RAISERROR ('O NIF do vendedor fornecido não existe na tabela Vendedor.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        INSERT INTO Produto (VendedorNIF, Nome, Preco)
        VALUES (@VendedorNIF, @Nome, @Preco);
		
		SET @ProdutoID = SCOPE_IDENTITY();

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
-- inserir comentario a um vendedor
CREATE PROCEDURE sp_InsertComentario
    @CompradorNIF INT,
    @VendedorNIF INT,
    @Conteudo NVARCHAR(MAX)
AS
BEGIN
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Verificar se o CompradorNIF existe na tabela Comprador
        IF NOT EXISTS (SELECT 1 FROM Comprador WHERE NIF = @CompradorNIF)
        BEGIN
            RAISERROR ('O NIF do comprador fornecido não existe na tabela Comprador.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Verificar se o VendedorNIF existe na tabela Vendedor
        IF NOT EXISTS (SELECT 1 FROM Vendedor WHERE NIF = @VendedorNIF)
        BEGIN
            RAISERROR ('O NIF do vendedor fornecido não existe na tabela Vendedor.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Inserir o comentário na tabela Comentario
        INSERT INTO Comentario (CompradorNIF, VendedorNIF, Conteudo)
        VALUES (@CompradorNIF, @VendedorNIF, @Conteudo);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO
CREATE PROCEDURE sp_AdicionarCaracteristicaProduto
    @ProdutoID INT,
    @NomeCaracteristica NVARCHAR(255),
    @ValorCaracteristica NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @CaracteristicaID INT;

    -- Verificar se a característica já existe
    SELECT @CaracteristicaID = CaracteristicaID
    FROM Caracteristica
    WHERE Nome = @NomeCaracteristica;

    -- Se a característica não existir cria-la
    IF @CaracteristicaID IS NULL
    BEGIN
        INSERT INTO Caracteristica (Nome)
        VALUES (@NomeCaracteristica);
        -- Obter o ID da nova característica
        SELECT @CaracteristicaID = SCOPE_IDENTITY();
    END

    -- Associar a característica ao produto com o valor fornecido
    INSERT INTO ProdutoCaracteristica (ProdutoID, CaracteristicaID, Valor)
    VALUES (@ProdutoID, @CaracteristicaID, @ValorCaracteristica);
END
GO
