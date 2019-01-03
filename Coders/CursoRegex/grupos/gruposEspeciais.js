const texto = 'Testando, grupos especiais!'

//lookahead
console.log(texto.match(/\w+(?=,|!)/g))
