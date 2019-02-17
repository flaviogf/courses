package oo.encapsulamento

import collections.print

//protected fun protegido() = 1

private fun privado() = 1

fun publico() = 1

internal fun interno() = 1

open class Objeto(val nome: String, val descricao: String) {

    init {
        println("Chamada metodo privado ${metodoPrivado()}")
    }

    protected fun metodoProtegido() = 1

    fun metodoPublico() = 1

    internal fun metodoInterno() = 1 // interno ao projeto

    private fun metodoPrivado() = 1
}

class ObjetoFilho(nome: String, descricao: String) : Objeto(nome, descricao) {

    fun testaNiveldeAcesso() {
        super.metodoProtegido().print()
        super.metodoInterno().print()
        super.metodoPublico().print()
        //super.metodoPrivado()
    }
}

fun main(args: Array<String>) {
    Objeto("obj1", "...").metodoPublico().print()
    Objeto("obj2", "...").metodoInterno().print()
    ObjetoFilho("obj3", "...").testaNiveldeAcesso()
    //Objeto("","").metodoProtegido()
    //Objeto("", "").metodoPrivado()
}