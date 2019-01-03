const texto = '$*-+?.'

console.log(texto.match(/[-$*+?.]/g))
console.log(texto.match(/[$-?]/g))
console.log(texto.match(/[$*\-+?.]./g))
