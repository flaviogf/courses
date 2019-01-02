package capitulo2.exemploenum

import capitulo2.exemploenum.Cor.BRANCO
import capitulo2.exemploenum.Cor.PRETO

enum class Cor(val r: Int, val g: Int, val b: Int) {

    PRETO(0, 0, 0),
    BRANCO(255, 255, 255);

    fun rgb() = r * g * b
}

fun testaWhen(cor: Cor) = when (cor) {
    PRETO -> println(cor.rgb())
    BRANCO -> println(cor.r)
}

fun misturaCor(cor1: Cor, cor2: Cor) {
    when (setOf(cor1, cor2)) {
        setOf(PRETO, BRANCO) -> println("ok")
        setOf(PRETO, PRETO) -> println("ok")
        else -> println("nao")
    }
}

fun main(args: Array<String>) {
    testaWhen(PRETO)
    testaWhen(BRANCO)
    misturaCor(PRETO, PRETO)
    misturaCor(BRANCO, BRANCO)
}
