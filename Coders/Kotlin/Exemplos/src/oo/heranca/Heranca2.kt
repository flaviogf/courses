package oo.heranca

open class Pai(val nome: String)

class Filho : Pai {

    val altura: Double

    constructor(nome: String, altura: Double) : super(nome) {
        this.altura = altura
    }

    constructor(nome: String) : this(nome, 0.0)
}