package capitulo2.exemplosmartcastcomwhen

interface Expressao

class Numero(val valor: Int) : Expressao

class Soma(val esquerda: Expressao, val direita: Expressao) : Expressao

fun validaComIfSemExpressao(expressao: Expressao): Int {
    if (expressao is Numero) {
        return expressao.valor
    } else if (expressao is Soma) {
        return validaComIfSemExpressao(expressao.esquerda) + validaComIfSemExpressao(expressao.direita)
    } else {
        throw IllegalArgumentException()
    }
}

fun validaComIfComExpressao(expressao: Expressao): Int =
        if (expressao is Numero) {
            expressao.valor
        } else if (expressao is Soma) {
            validaComIfComExpressao(expressao.esquerda) + validaComIfComExpressao(expressao.direita)
        } else {
            throw IllegalArgumentException()
        }

fun validaComWhen(expressao: Expressao): Int =
        when (expressao) {
            is Numero -> expressao.valor
            is Soma -> validaComWhen(expressao.direita) + validaComWhen(expressao.esquerda)
            else -> throw IllegalArgumentException()
        }

fun validaComWhenComLog(expressao: Expressao): Int =
        when (expressao) {
            is Numero -> {
                println("numero ${expressao.valor}")
                expressao.valor
            }
            is Soma -> {
                val direita = validaComWhenComLog(expressao.direita)
                val esquerda = validaComWhenComLog(expressao.esquerda)
                println("soma $esquerda + $direita")
                direita + esquerda
            }
            else -> throw IllegalArgumentException()
        }

fun main(args: Array<String>) {
    val soma = Soma(Soma(Numero(1), Numero(2)), Numero(3))
    var resultado = validaComIfSemExpressao(soma)
    println(resultado)
    resultado = validaComIfComExpressao(soma)
    println(resultado)
    resultado = validaComWhen(soma)
    println(resultado)
    resultado = validaComWhenComLog(soma)
    println(resultado)
}
