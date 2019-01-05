SELECT * FROM [NOTAS FISCAIS];

SELECT * FROM [TABELA DE VENDEDORES];

SELECT V.[NOME], YEAR(N.[DATA]) 'ANO', COUNT(*) 'QUANTIDADE' FROM [TABELA DE VENDEDORES] V
INNER JOIN [NOTAS FISCAIS] N
ON V.[MATRICULA] = N.[MATRICULA]
GROUP BY V.[NOME], YEAR(N.[DATA])
ORDER BY YEAR(N.[DATA]), V.[NOME]

SELECT
tc.[NOME], COUNT(*)
FROM [TABELA DE CLIENTES] tc 
INNER JOIN [NOTAS FISCAIS] nf
ON tc.[CPF] = nf.[CPF]
GROUP BY tc.[NOME]

SELECT
tc.[NOME], COUNT(*)
FROM [TABELA DE CLIENTES] tc 
LEFT JOIN [NOTAS FISCAIS] nf
ON tc.[CPF] = nf.[CPF]
GROUP BY tc.[NOME]

SELECT
tv.[NOME] 'VENDEDOR', tc.[NOME] 'CLIENTE', tv.[BAIRRO]
FROM [TABELA DE VENDEDORES] tv
INNER JOIN [TABELA DE CLIENTES] tc
ON tv.[BAIRRO] = tc.[BAIRRO]

SELECT
tv.[NOME] 'VENDEDOR', tc.[NOME] 'CLIENTE', tv.[BAIRRO]
FROM [TABELA DE VENDEDORES] tv
LEFT JOIN [TABELA DE CLIENTES] tc
ON tv.[BAIRRO] = tc.[BAIRRO]

SELECT
tv.[NOME] 'VENDEDOR', tc.[NOME] 'CLIENTE', tv.[BAIRRO]
FROM [TABELA DE VENDEDORES] tv
RIGHT JOIN [TABELA DE CLIENTES] tc
ON tv.[BAIRRO] = tc.[BAIRRO]

SELECT
tv.[NOME] 'VENDEDOR', tc.[NOME] 'CLIENTE', tv.[BAIRRO]
FROM [TABELA DE VENDEDORES] tv
FULL JOIN [TABELA DE CLIENTES] tc
ON tv.[BAIRRO] = tc.[BAIRRO]

SELECT
tv.[NOME] 'VENDEDOR', tc.[NOME] 'CLIENTE', tv.[BAIRRO]
FROM [TABELA DE VENDEDORES] tv
CROSS JOIN [TABELA DE CLIENTES] tc

SELECT tc.[BAIRRO] FROM [TABELA DE CLIENTES] tc
UNION
SELECT tv.[BAIRRO] FROM [TABELA DE VENDEDORES] tv

SELECT tc.[BAIRRO] FROM [TABELA DE CLIENTES] tc
UNION ALL
SELECT tv.[BAIRRO] FROM [TABELA DE VENDEDORES] tv

SELECT COUNT(*) 'TOTAL' FROM (
	SELECT
	nf.[DATA], SUM(nf.[IMPOSTO]) 'TOTAL IMPOSTO'
	FROM [NOTAS FISCAIS] nf
	GROUP BY nf.[DATA]) nft
	WHERE nft.[TOTAL IMPOSTO] < 8
UNION
SELECT COUNT(*) FROM (
	SELECT
	nf.[DATA], SUM(nf.[IMPOSTO]) 'TOTAL IMPOSTO'
	FROM [NOTAS FISCAIS] nf
	GROUP BY nf.[DATA]) nft
