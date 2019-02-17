package fundamentos.operadores

data class Carro(val marca: String, val modelo: String)

fun main(args: Array<String>) {
    val (marca, modelo) = Carro("Chevrolet", "Camaro")
    println("$marca - $modelo")
    val (aluno1, aluno2) = listOf("Flavio", "Fernando")
    println("$aluno1 - $aluno2")
    val (_, _, terceiroLugar) = listOf("Corinthians", "São Paulo", "Palmeiras")
    println("$terceiroLugar teceiro colocado")
}