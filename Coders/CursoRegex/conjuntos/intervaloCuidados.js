const texto = 'ABC [abc] a-c'

console.log(texto.match(/[a-z]/gi))
console.log(texto.match(/a-c/g))
console.log(texto.match(/[A-z]/g))
console.log(texto.match(/[Z-a]/g))
// console.log(texto.match(/[a-Z]/g)) erro de sintaxe
