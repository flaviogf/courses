package fundamentos.controles

fun main(args: Array<String>) {
    var linha: Int? = null
    while (linha != -1) {
        linha = readLine()?.toIntOrNull() ?: 0
        println("Você digitou $linha")
    }
}