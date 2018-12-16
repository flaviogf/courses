package funcoes

fun potencia(base: Int = 2, expoente: Int = 1): Int {
    return Math.pow(base.toDouble(), expoente.toDouble()).toInt()
}

fun main(args: Array<String>) {
    println(potencia(1, 2))
    println(potencia(base = 2))
    println(potencia(2))
    println(potencia(expoente = 10))
}