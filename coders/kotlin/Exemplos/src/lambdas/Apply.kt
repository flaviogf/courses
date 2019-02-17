package lambdas

class Calculadora2 {

    var resultado: Int = 0

    fun soma(x: Int, y: Int) {
        resultado += x + y
    }

    fun add(x: Int) {
        resultado += x
    }
}

fun main(args: Array<String>) {
    val calc = Calculadora2()
    calc.apply { soma(10, 10) }.apply { add(10) }.apply { println(resultado) }
    "teste".apply { println(toUpperCase()) }.apply { println(this) }
}