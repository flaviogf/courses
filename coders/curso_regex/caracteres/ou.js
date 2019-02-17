const texto = 'Diga sim não, ou não sei'

console.log(texto.match(/sim|não|sei/g))
console.log(texto.match(/sim|não sei|não/g))
console.log(texto.match(/sim|n.o|sei/g))
