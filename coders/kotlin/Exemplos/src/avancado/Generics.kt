package avancado

import collections.print

class Caixa<T>(objeto: T) {

    private val objetos = mutableListOf<T>()

    init {
        adicionar(objeto)
    }

    fun adicionar(objeto: T): Caixa<T> {
        objetos.add(objeto)
        return this
    }

    override fun toString(): String {
        return objetos.toString()
    }
}

fun main(args: Array<String>) {
    val materiaisEscolares = Caixa("Caneta")
    Caixa(1).adicionar(2).adicionar(5).print()
    with(materiaisEscolares) {
        adicionar("Lapis")
        adicionar("Borracha")
        print()
    }
}