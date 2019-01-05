IF OBJECT_ID('[dbo].[sp_busca_notas_por_cpf_entre_data_inicio_e_data_fim]', 'P') IS NOT NULL
	DROP PROCEDURE [dbo].[sp_busca_notas_por_cpf_entre_data_inicio_e_data_fim]
GO

CREATE PROCEDURE [dbo].[sp_busca_notas_por_cpf_entre_data_inicio_e_data_fim]
	@CPF VARCHAR(11),
	@DATA_INICIO DATE,
	@DATA_FIM DATE
AS
BEGIN
	SELECT TDC.[CPF] ,TDC.[NOME], NF.[DATA], SUM(INF.[PREÇO] * INF.[QUANTIDADE]) TOTAL_NOTA FROM [dbo].[TABELA DE CLIENTES] TDC
	INNER JOIN [dbo].[NOTAS FISCAIS] NF
	ON NF.[CPF] = TDC.[CPF]
	INNER JOIN [dbo].[ITENS NOTAS FISCAIS] INF
	ON INF.[NUMERO] = NF.[NUMERO]
	GROUP BY TDC.[CPF], TDC.[NOME], NF.[DATA]
	ORDER BY TDC.[NOME]
END
GO

IF OBJECT_ID('[dbo].[sp_buscar_cpf_com_maior_valor_de_nota]', 'P') IS NOT NULL
	DROP PROCEDURE [dbo].[sp_buscar_cpf_com_maior_valor_de_nota]
GO

CREATE PROCEDURE [dbo].[sp_buscar_cpf_com_maior_valor_de_nota]
	@DATA_MAIOR_NOTA DATE OUTPUT
AS
BEGIN
	DECLARE @TABELA AS TABLE (CPF VARCHAR(11), NOME VARCHAR(50), DATA DATE, TOTAL_NOTA DECIMAL(10,2))
	INSERT INTO @TABELA EXEC [dbo].[sp_busca_notas_por_cpf_entre_data_inicio_e_data_fim] '1471156710', '2016-01-01', '2018-01-01'
	SELECT TOP 1 @DATA_MAIOR_NOTA = DATA FROM @TABELA ORDER BY TOTAL_NOTA
END
GO

EXEC [dbo].[sp_busca_notas_por_cpf_entre_data_inicio_e_data_fim] '1471156710', '2016-01-01', '2018-01-01'
GO

DECLARE @DATA_MAIOR_NOTA DATE
EXEC [dbo].[sp_buscar_cpf_com_maior_valor_de_nota] @DATA_MAIOR_NOTA OUTPUT
SELECT @DATA_MAIOR_NOTA AS DATA_MAIOR_NOTA
GO
