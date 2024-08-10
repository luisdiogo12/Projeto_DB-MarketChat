
-- Limpar tabelas na ordem correta
DELETE FROM Comentario;
DELETE FROM Produto;
DELETE FROM Mensagem;
DELETE FROM Chat;
DELETE FROM Vendedor;
DELETE FROM Comprador;
DELETE FROM Cliente;
DELETE FROM Funcionario;
DELETE FROM Utilizador;
DELETE FROM Caracteristica;
DELETE FROM ProdutoCaracteristica;

	
--clientes
EXEC sp_InsertCliente 
@NIF = 100000000, @Nome = 'A', @Email = 'a@example.com', @Hash = 'hash_value1', @N_telemovel = 911111111, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 1, @IsVendedor = 0;	
EXEC sp_InsertCliente 
@NIF = 100000001, @Nome = 'B', @Email = 'b@example.com', @Hash = 'hash_value2', @N_telemovel = 911111112, @Rua = 'Rua B', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 1, @IsVendedor = 0;
EXEC sp_InsertCliente 
@NIF = 100000002, @Nome = 'C', @Email = 'c@example.com', @Hash = 'hash_value3', @N_telemovel = 911111113, @Rua = 'Rua C', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 1, @IsVendedor = 0;
EXEC sp_InsertCliente 
@NIF = 100000003, @Nome = 'D', @Email = 'd@example.com', @Hash = 'hash_value4', @N_telemovel = 911111114, @Rua = 'Rua D', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 1, @IsVendedor = 0;
EXEC sp_InsertCliente 
@NIF = 100000004, @Nome = 'E', @Email = 'e@example.com', @Hash = 'hash_value5', @N_telemovel = 911111115, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 1, @IsVendedor = 0;
EXEC sp_InsertCliente 
@NIF = 100000005, @Nome = 'F', @Email = 'f@example.com', @Hash = 'hash_value6', @N_telemovel = 911111116, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 0, @IsVendedor = 1;
EXEC sp_InsertCliente 
@NIF = 100000006, @Nome = 'G', @Email = 'g@example.com', @Hash = 'hash_value7', @N_telemovel = 911111117, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 0, @IsVendedor = 1;
EXEC sp_InsertCliente 
@NIF = 100000007, @Nome = 'H', @Email = 'h@example.com', @Hash = 'hash_value8', @N_telemovel = 911111118, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 0, @IsVendedor = 1;
EXEC sp_InsertCliente 
@NIF = 100000008, @Nome = 'I', @Email = 'i@example.com', @Hash = 'hash_value9', @N_telemovel = 911111119, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 0, @IsVendedor = 1;	
EXEC sp_InsertCliente 
@NIF = 100000009, @Nome = 'J', @Email = 'j@example.com', @Hash = 'hash_value10', @N_telemovel = 911111121, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 0, @IsVendedor = 1;
EXEC sp_InsertCliente 
@NIF = 100000010, @Nome = 'K', @Email = 'k@example.com', @Hash = 'hash_value11', @N_telemovel = 911111131, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 1, @IsVendedor = 1;
EXEC sp_InsertCliente 
@NIF = 100000011, @Nome = 'L', @Email = 'l@example.com', @Hash = 'hash_value12', @N_telemovel = 911111141, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 1, @IsVendedor = 1;
EXEC sp_InsertCliente 
@NIF = 100000012, @Nome = 'M', @Email = 'm@example.com', @Hash = 'hash_value13', @N_telemovel = 911111151, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 1, @IsVendedor = 1;
EXEC sp_InsertCliente 
@NIF = 100000013, @Nome = 'N', @Email = 'n@example.com', @Hash = 'hash_value14', @N_telemovel = 911111161, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 1, @IsVendedor = 1;
EXEC sp_InsertCliente 
@NIF = 100000014, @Nome = 'O', @Email = 'o@example.com', @Hash = 'hash_value15', @N_telemovel = 911111171, @Rua = 'Rua A', @Localidade = 'Localidade A', @Cod_Postal = '1234-567', @IsComprador = 1, @IsVendedor = 1;
--funcionarios
INSERT INTO Utilizador (NIF, Nome, Email, Hash, N_telemovel)
VALUES (100099999, 'Z', 'z@example.com','hash_value99999',967799999);
INSERT INTO Funcionario (NIF,Funcao, Salario)
VALUES (100099999, 'gerente', 5000.00);
EXEC sp_InsertFuncionario 
@GerenteNIF=100099999, @NIF = 100000017, @Nome = 'P', @Email = 'p@example.com', @Hash = 'hash_value16', @N_telemovel = 967777717, @Funcao='especialista', @Salario = 2501.00;
EXEC sp_InsertFuncionario 
@GerenteNIF=100099999, @NIF = 100000027, @Nome = 'Q', @Email = 'q@example.com', @Hash = 'hash_value17', @N_telemovel = 967777727, @Funcao='especialista', @Salario = 2502.00;
EXEC sp_InsertFuncionario 
@GerenteNIF=100099999, @NIF = 100000037, @Nome = 'R', @Email = 'r@example.com', @Hash = 'hash_value18', @N_telemovel = 967777737, @Funcao='especialista', @Salario = 2503.00;
EXEC sp_InsertFuncionario 
@GerenteNIF=100099999, @NIF = 100000047, @Nome = 'S', @Email = 's@example.com', @Hash = 'hash_value19', @N_telemovel = 967777747, @Funcao='especialista', @Salario = 2504.00;
EXEC sp_InsertFuncionario 
@GerenteNIF=100099999, @NIF = 100000057, @Nome = 'T', @Email = 't@example.com', @Hash = 'hash_value20', @N_telemovel = 967777757, @Funcao='especialista', @Salario = 2505.00;
EXEC sp_InsertFuncionario 
@GerenteNIF=100099999, @NIF = 100000067, @Nome = 'U', @Email = 'u@example.com', @Hash = 'hash_value21', @N_telemovel = 967777767, @Funcao='especialista', @Salario = 2506.00;
EXEC sp_InsertFuncionario 
@GerenteNIF=100099999, @NIF = 100000077, @Nome = 'V', @Email = 'v@example.com', @Hash = 'hash_value22', @N_telemovel = 967777777, @Funcao='especialista', @Salario = 2507.00;
EXEC sp_InsertFuncionario 
@GerenteNIF=100099999, @NIF = 100000087, @Nome = 'W', @Email = 'w@example.com', @Hash = 'hash_value23', @N_telemovel = 967777787, @Funcao='especialista', @Salario = 2508.00;
--chats
EXEC sp_CreateChat @A_NIF = 100000000, @B_NIF = 100000005;
EXEC sp_CreateChat @A_NIF = 100000001, @B_NIF = 100000010;
EXEC sp_CreateChat @A_NIF = 100000002, @B_NIF = 100000087;
--mensagens
EXEC sp_SendMensagem @Para = 100000000, @EnviadoPor = 100000005, @Conteudo = 'Olá, tudo bem?';
EXEC sp_SendMensagem @Para = 100000005, @EnviadoPor = 100000000, @Conteudo = 'Sim, em que posso ajudar?';
EXEC sp_SendMensagem @Para = 100000000, @EnviadoPor = 100000005, @Conteudo = 'Tenho umas questoes em relacao ao seu produto';

EXEC sp_SendMensagem @Para = 100000001, @EnviadoPor = 100000010, @Conteudo = 'Olá, tudo bem1?';
EXEC sp_SendMensagem @Para = 100000010, @EnviadoPor = 100000001, @Conteudo = 'Sim, em que posso ajudar1?';
EXEC sp_SendMensagem @Para = 100000001, @EnviadoPor = 100000010, @Conteudo = 'Tenho umas questoes em relacao ao seu produto1';

EXEC sp_SendMensagem @Para = 100000002, @EnviadoPor = 100000087, @Conteudo = 'Olá, tudo bem2?';
EXEC sp_SendMensagem @Para = 100000087, @EnviadoPor = 100000002, @Conteudo = 'Sim, em que posso ajudar2?';
EXEC sp_SendMensagem @Para = 100000002, @EnviadoPor = 100000087, @Conteudo = 'Tenho umas questoes em relacao ao site2';
--produtos
DECLARE @NovoProdutoID INT;
EXEC sp_InsertProduto @VendedorNIF = 100000005, @Nome = 'Produto A', @Preco = 1001.00, @ProdutoID = @NovoProdutoID OUTPUT;
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'Processador', @ValorCaracteristica = 'Intel i5';
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'RAM', @ValorCaracteristica = '16GB';
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'Tamanho da Tela', @ValorCaracteristica = '6.5"';

EXEC sp_InsertProduto @VendedorNIF = 100000005, @Nome = 'Produto B', @Preco = 1002.00;
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'Processador', @ValorCaracteristica = 'Intel i7';
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'RAM', @ValorCaracteristica = '32GB';
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'Tamanho da Tela', @ValorCaracteristica = '6"';

EXEC sp_InsertProduto @VendedorNIF = 100000006, @Nome = 'Produto C', @Preco = 1003.00;
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'Processador', @ValorCaracteristica = 'Intel i5';
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'RAM', @ValorCaracteristica = '32GB';
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'Tamanho da Tela', @ValorCaracteristica = '7.5"';

EXEC sp_InsertProduto @VendedorNIF = 100000007, @Nome = 'Produto D', @Preco = 1004.00;
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'Processador', @ValorCaracteristica = 'Intel i3';
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'RAM', @ValorCaracteristica = '64GB';
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'Tamanho da Tela', @ValorCaracteristica = '6.5"';

EXEC sp_InsertProduto @VendedorNIF = 100000007, @Nome = 'Produto E', @Preco = 1005.00;
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'Processador', @ValorCaracteristica = 'Intel i9';
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'RAM', @ValorCaracteristica = '32GB';
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'Tamanho da Tela', @ValorCaracteristica = '14.5"';

EXEC sp_InsertProduto @VendedorNIF = 100000007, @Nome = 'Produto F', @Preco = 1006.00;
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'Processador', @ValorCaracteristica = 'Intel i5';
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'RAM', @ValorCaracteristica = '4GB';
EXEC sp_AdicionarCaracteristicaProduto @ProdutoID = @NovoProdutoID, @NomeCaracteristica = 'Tamanho da Tela', @ValorCaracteristica = '11.5"';
--comentarios
EXEC sp_InsertComentario @CompradorNIF = 100000001, @VendedorNIF = 100000005, @Conteudo = 'Excelente vendedor!';
EXEC sp_InsertComentario @CompradorNIF = 100000002, @VendedorNIF = 100000005, @Conteudo = 'Excelente vendedor2!';
EXEC sp_InsertComentario @CompradorNIF = 100000001, @VendedorNIF = 100000006, @Conteudo = 'Excelente vendedor1!';
EXEC sp_InsertComentario @CompradorNIF = 100000002, @VendedorNIF = 100000006, @Conteudo = 'Excelente vendedor12!';
