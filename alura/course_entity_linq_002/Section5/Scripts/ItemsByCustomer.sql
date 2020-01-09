IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ItemsByCustomer')
	DROP PROCEDURE [dbo].[ItemsByCustomer]
GO

CREATE PROCEDURE [dbo].[ItemsByCustomer]
@ClienteId INT
AS
BEGIN
	SELECT 
	[inf].[NotaFiscalId],
	[inf].[FaixaId],
	[inf].[PrecoUnitario],
	[inf].[Quantidade],
	[f].[Nome]
	FROM [dbo].[ItemNotaFiscal] [inf]
	INNER JOIN [dbo].[NotaFiscal] [nf]
	ON [inf].[NotaFiscalId] = [nf].[NotaFiscalId]
	INNER JOIN [dbo].[Cliente] [c]
	ON [nf].[ClienteId] = [c].[ClienteId]
	INNER JOIN [dbo].[Faixa] f
	ON [inf].[FaixaId] = [f].[FaixaId]
	WHERE [c].[ClienteId] = @ClienteId
END
GO
