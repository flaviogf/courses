package fundamentos

import fundamentos.pacoteA.simpleFuncao as funcaoSimples
import fundamentos.pacoteA.Tipo
import fundamentos.pacoteB.*

fun main(args: Array<String>) {
    val texto = funcaoSimples("teste")
    println(texto)
    println(Tipo.Primario)
    val soma = somar(1,2)
    println(soma)
}