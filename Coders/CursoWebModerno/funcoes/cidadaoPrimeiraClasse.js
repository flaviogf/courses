function fun1() {
  console.log('fun1')
}

const fun2 = function () {
  console.log('fun2')
}

const funs = [function () { console.log('fun3') }, fun1, fun2]

funs.forEach(it => it())

const soma = x => y => x + y
const subtracao = x => y => x - y
const multiplicacao = x => y => x * y
const divisao = x => y => x / y

const cincoMais = soma(5)

const operacao = x => y => fn => fn(x)(y)

console.log(soma(4)(4))
console.log(cincoMais(5))
console.log(cincoMais(10))

console.log('Soma: ' + operacao(10)(2)(soma))
console.log('Subtracao: ' + operacao(10)(2)(subtracao))
console.log('Multiplicacao: ' + operacao(10)(2)(multiplicacao))
console.log('Divisao: ' + operacao(10)(2)(divisao))

const num = x => fn => fn ? fn(x) : (x)

const mais = x => fn => num(soma(x)(fn()))

const menos = x => fn => num(subtracao(x)(fn()))

const resultado = num(10)(mais)(num(20))(mais)(num(30))(menos)(num(25))

console.log(resultado())
