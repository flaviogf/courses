package fundamentos.controles

fun main(args: Array<String>) {
    val nota: Double = -1.0
    if (nota in 9..10) {
        println("Fantastico")
    } else if (nota in 7..8) {
        println("Parabens")
    } else if (nota in 4..6) {
        println("Tem como recuperar")
    } else if (nota in 0..3) {
        println("Reprovado")
    } else {
        println("Nota inválida")
    }
}