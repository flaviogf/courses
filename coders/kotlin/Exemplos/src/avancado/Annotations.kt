package avancado

import collections.print
import kotlin.reflect.KProperty
import kotlin.reflect.full.instanceParameter
import kotlin.reflect.jvm.isAccessible

annotation class Positivo
annotation class NaoVazio

class Pessoa(@NaoVazio val nome: String, @Positivo val idade: Int)

fun getValor(objeto: Any, nomeAtributo: String): Any? {
    var valor: Any? = null
    val atributo = objeto::class.members.firstOrNull { it.name == nomeAtributo } as KProperty
    atributo?.apply {
        isAccessible = false
        valor = getter.property
        print(getter)
        isAccessible = true
    }
    return valor
}


fun validar(objeto: Any): List<String> {
    val erros = mutableListOf<String>()
    objeto::class.members.forEach { membro ->
        membro.annotations.forEach { annotations ->
            val valor = getValor(objeto, membro.name)
            when (annotations) {
                is Positivo -> {
                    if (valor !is Int || valor <= 0) {
                        erros.add("Valor $valor não é um numero positivo")
                    }
                }
                is NaoVazio -> {
                    if (valor !is String || valor.trim().isEmpty()) {
                        erros.add("Valor $valor não pode ser vazio")
                    }
                }
            }
        }
    }
    return erros
}

fun main(args: Array<String>) {
    val pessoa = Pessoa("Flávio", 21)
    val pessoa2 = Pessoa("", 0)
}