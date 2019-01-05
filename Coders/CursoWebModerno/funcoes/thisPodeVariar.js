function fun1() {
  console.log(this === window)
}

const fun2 = () => console.log(this === window)

const pessoa = {
  nome: 'flavio',
  fun1: fun1,
  fun2: fun2
}

pessoa.fun1() // false
pessoa.fun2() // true 

fun1() // true
fun2() // true
