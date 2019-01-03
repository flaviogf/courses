const texto = '1,2,3,4,5,6,7,8,9,0'

console.log(texto.match(/1.2/g))
console.log(texto.match(/1..2/g))
console.log(texto.match(/1..,/g))

const notas = '8.3,9.8,8.0,10.0'
console.log(notas.match(/8../g))
console.log(notas.match(/.\../g))
