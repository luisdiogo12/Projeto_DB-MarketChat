
USE p2g4;
GO

CREATE VIEW vw_ProdutosCaracteristicas
AS
SELECT p.ProdutoID ,p.Nome AS NomeProduto ,p.Preco, p.VendedorNIF,c.CaracteristicaID ,c.Nome AS NomeCaracteristica ,pc.Valor AS ValorCaracteristica
FROM 
	Produto p
JOIN 
	ProdutoCaracteristica pc ON p.ProdutoID = pc.ProdutoID
JOIN 
	Caracteristica c ON pc.CaracteristicaID = c.CaracteristicaID;
GO

CREATE VIEW vw_FiltrosValores
AS
SELECT 
	c.Nome AS NomeFiltro,pc.Valor AS ValorFiltro
FROM 
    ProdutoCaracteristica pc
JOIN 
    Caracteristica c ON pc.CaracteristicaID = c.CaracteristicaID
GO
CREATE VIEW vw_Compradores
AS
SELECT u.NIF,u.Nome,u.Email,u.[Hash],u.N_telemovel,c.Cl_ID,c.Rua,c.Localidade,c.Cod_Postal
FROM 
    Comprador cp
JOIN 
    Cliente c ON cp.NIF = c.NIF
JOIN 
    Utilizador u ON c.NIF = u.NIF;
GO
CREATE VIEW vw_Vendedores
AS
SELECT u.NIF,u.Nome,u.Email,u.Hash,u.N_telemovel,c.Cl_ID,c.Rua,c.Localidade,c.Cod_Postal,v.N_likes,v.N_deslikes
FROM 
    Vendedor v
JOIN 
    Cliente c ON v.NIF = c.NIF
JOIN 
    Utilizador u ON c.NIF = u.NIF;
GO
CREATE VIEW vw_Funcionarios
AS
SELECT u.NIF,u.Nome,u.Email,u.Hash,u.N_telemovel,f.F_ID,f.Funcao,f.Salario
FROM 
    Funcionario f
JOIN 
    Utilizador u ON f.NIF = u.NIF;
GO