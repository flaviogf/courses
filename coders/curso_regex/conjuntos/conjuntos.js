const texto = '1,2,3,4,5,6a.b c!d?e[f'
const texto2 = 'Jão não vai passear na moto'

console.log(texto.match(/[02468]/g))
console.log(texto2.match(/n[aã]o/g))
