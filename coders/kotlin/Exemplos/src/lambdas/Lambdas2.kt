package lambdas

interface Operacao {
    fun executar(x: Int, y: Int): Int
}

class Multiplicacao : Operacao {

    override fun executar(x: Int, y: Int): Int {
        return x * y
    }
}

class Calculadora {

    fun calcular(x: Int, y: Int, operacao: Operacao): Int {
        return operacao.executar(x, y)
    }

    fun calcular(x: Int, y: Int, operacao: (Int, Int) -> Int): Int {
        return operacao(x, y)
    }
}

fun main(args: Array<String>) {
    val calculadora = Calculadora()
    val resultado1 = calculadora.calcular(10, 10, Multiplicacao())
    val subtracao = { x: Int, y: Int -> x - y }
    val resultado2 = calculadora.calcular(10, 5, subtracao)
    val resultado3 = calculadora.calcular(10, 10) { x: Int, y: Int -> x + y }
    println("$resultado1 $resultado2 $resultado3")
}