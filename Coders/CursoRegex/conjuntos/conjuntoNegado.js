const texto = '1,2,3,4,5,6,7,8,9,10 a.b c?d!e[f'

console.log(texto.match(/[^1-5 ,.\[?!]/g))
console.log(texto.match(/[^\d!,\s.?\[\]]/g))
