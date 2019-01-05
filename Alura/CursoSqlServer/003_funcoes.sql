CREATE FUNCTION [dbo].[TOTAL_FATURAMENTO_CLIENTE] (@CPF VARCHAR(50)) RETURNS FLOAT
AS
BEGIN
	DECLARE @TOTAL FLOAT
	SELECT @TOTAL = SUM([PRE�O] * [QUANTIDADE]) FROM [dbo].[ITENS NOTAS FISCAIS] INF
	INNER JOIN [dbo].[NOTAS FISCAIS] NF
	ON INF.NUMERO = NF.NUMERO
	WHERE NF.CPF = @CPF
	IF @TOTAL IS NULL SET @TOTAL = 0
	RETURN @TOTAL
END
GO

SELECT NOME, CPF, [dbo].[TOTAL_FATURAMENTO_CLIENTE](CPF) TOTAL FROM [dbo].[TABELA DE CLIENTES]
GO

DROP FUNCTION [dbo].[TOTAL_FATURAMENTO_CLIENTE]
GO
