package capitulo2.iteracao

import java.util.*

fun fizzBuzz(numero: Int) = when {
    numero % 15 == 0 -> "FizzBuzz"
    numero % 3 == 0 -> "Fizz"
    numero % 5 == 0 -> "Buzz"
    else -> "$numero"
}

fun main(args: Array<String>) {
    for (i in 1..100) {
        println(fizzBuzz(i))
    }

    for (i in 100 downTo 1 step 2) {
        println(fizzBuzz(i))
    }

    val representacaoBinaria = TreeMap<Char, String>()

    for (c in 'A'..'F') {
        representacaoBinaria[c] = Integer.toBinaryString(c.toInt())
    }

    for ((chave, valor) in representacaoBinaria) {
        println("$chave = $valor")
    }

    val list = arrayListOf("10", "20", "30")
    for ((indice, valor) in list.withIndex()) {
        println("$indice - $valor")
    }
}
