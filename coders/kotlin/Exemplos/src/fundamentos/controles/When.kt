package fundamentos.controles

fun main(args: Array<String>) {
    val nota: Double = 3.2
    when (nota) {
        in 7..10 -> println("Aprovado")
        in 4..6 -> println("Recuperação")
        in 0..3 -> println("Reprovado")
        else -> println("Nota inválida")
    }
}