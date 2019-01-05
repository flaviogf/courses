CREATE PROCEDURE Busca_Entidades @Entidade VARCHAR(50)
AS
BEGIN
	IF @Entidade = 'Clientes'
		SELECT [CPF] FROM [TABELA DE CLIENTES]
	ELSE IF @Entidade = 'Vendedores'
		SELECT [MATRICULA] FROM [TABELA DE VENDEDORES]
END

EXEC Busca_Entidades @Entidade = 'Clientes'
EXEC Busca_Entidades @Entidade = 'Vendedores'
