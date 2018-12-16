package avancado

import collections.print

data class Ponto(val x: Int, val y: Int) {

    operator fun plus(other: Ponto): Ponto = Ponto(x + other.x, y + other.y)

    operator fun unaryMinus(): Ponto = Ponto(-x, -y)
}

fun main(args: Array<String>) {
    val ponto1 = Ponto(10, 20)
    val ponto2 = Ponto(10, 20)
    (ponto1 + ponto2).print()
    (-ponto1).print()
}