const pessoa = {
  nome: 'flavio',
  idade: 21
}

for (let attr in pessoa) {
  console.log(attr, pessoa[attr])
}
