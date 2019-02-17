const texto1 = 'De longe eu avistei o fogo e uma pessoa gritando: FOGOOOOOO'
const texto2 = 'There is a big fog in NYC'

const regex1 = /fogo+/gi

console.log(texto1.match(regex1))
console.log(texto2.match(regex1))

const texto3 = 'Os numeros: 0123456789.'

const regex2 = /\d+/g
console.log(texto3.match(regex2))

const regex3 = /\d/g
console.log(texto3.match(regex3))

const regex4 = /\d+?/g // não guloso
console.log(texto3.match(regex4))
