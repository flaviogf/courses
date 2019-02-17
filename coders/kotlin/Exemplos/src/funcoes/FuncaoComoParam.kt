package funcoes

class Operacoes {
    fun somar(num1: Int, num2: Int): Int {
        return num1 + num2
    }
}

fun somar(num1: Int, num2: Int): Int = num1 + num2

fun calc(num1: Int, num2: Int, funcao: (Int, Int) -> Int): Int = funcao(num1, num2)

fun main(args: Array<String>) {
    println(calc(1, 3, ::somar))
    println(calc(2, 2, Operacoes()::somar))
}
