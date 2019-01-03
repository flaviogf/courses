const texto = '1,2,3,4,5,6,a.b c?d!e[f'

console.log(texto.match(/\d/g)) // [0-9]
console.log(texto.match(/\D/g)) // [^0-9]

console.log(texto.match(/\w/g)) // [a-zA-Z0-9_]
console.log(texto.match(/\W/g)) // [^a-zA-Z0-9_]

console.log(texto.match(/\s/g)) 
console.log(texto.match(/\S/g)) 
