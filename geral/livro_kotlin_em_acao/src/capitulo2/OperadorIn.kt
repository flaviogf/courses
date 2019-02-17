package capitulo2

@JvmName("funcaoEhLetra")
fun ehLetra(c: Char) = c in 'a'..'z' || c in 'A'..'Z'

fun Char.ehLetra() = this in 'a'..'z' || this in 'A'..'Z'

@JvmName("funcaoNaoEhNumero")
fun naoEhNumero(c: Char) = c !in '0'..'9'

fun Char.naoEhNumero() = this !in '0'..'9'

class Teste {
    operator fun contains(numero: Int): Boolean = numero == 1
}

fun main(args: Array<String>) {
    println("a é letra ${ehLetra('a')}")
    println("1 é letra: ${ehLetra('1')}")
    println("1 é letra: ${'1'.ehLetra()}")
    println("1 esta em teste ${1 in Teste()}")
    println("2 esta em teste ${2 !in Teste()}")
    println("1 nao é numero ${'1'.naoEhNumero()}")
    println("a não em numero ${naoEhNumero('a')}")
}
