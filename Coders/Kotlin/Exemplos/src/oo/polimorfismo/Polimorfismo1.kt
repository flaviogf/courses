package oo.polimorfismo

import collections.print

open class Comida(val peso: Double)
class Arroz(peso: Double) : Comida(peso)
class Ovo(peso: Double) : Comida(peso)
class Feijao(peso: Double) : Comida(peso)

class Pessoa(var peso: Double) {

    fun comer(comida: Comida) {
        peso += comida.peso
    }

    override fun toString(): String {
        return "Peso atual $peso"
    }
}

fun main(args: Array<String>) {
    val arroz = Arroz(0.5)
    val ovo = Ovo(0.5)
    val feijao = Feijao(0.4)
    val pessoa = Pessoa(80.0)
    with(pessoa) {
        comer(arroz)
        comer(feijao)
        comer(ovo)
        print()
    }
}