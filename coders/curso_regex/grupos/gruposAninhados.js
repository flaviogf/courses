const texto = 'supermercado minimercado hipermercado mercado'

console.log(texto.match(/(super|mini|hiper)?mercado/g))
console.log(texto.match(/((su|hi)per|mini)?mercado/g))
