package avancado

import collections.print

fun fatorial(numero: Int): Int = when (numero) {
    in 0..1 -> 1
    in 2..Int.MAX_VALUE -> numero * fatorial(numero - 1)
    else -> throw IllegalArgumentException("Não existe fatorial de numero negativo")
}

fun main(args: Array<String>) {
    fatorial(5).print()
}