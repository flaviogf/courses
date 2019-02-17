package capitulo2.execoes

import java.io.BufferedReader
import java.io.StringReader

fun lehNumero(reader: BufferedReader) {
    try {
        val numero = reader.readLine().toInt()
        println(numero)
    } catch (e: NumberFormatException) {
        println("Erro ao formatar o numero")
    }
}

fun lehNumeroTryComoExpressao(numero: String): Int? =
        try {
            numero.toInt()
        } catch (e: NumberFormatException) {
            println("Erro ao formatar $numero")
            null
        }


fun main(args: Array<String>) {
    lehNumeroTryComoExpressao("2")
    lehNumeroTryComoExpressao("a")
    lehNumero(BufferedReader(StringReader("a")))
    lehNumero(BufferedReader(StringReader("2")))
}
