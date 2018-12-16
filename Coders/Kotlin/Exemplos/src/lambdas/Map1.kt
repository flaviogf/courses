package lambdas

fun main(args: Array<String>) {
    val alunos = arrayListOf("Flavio", "Fernando")
    alunos.map { it.toUpperCase() }.apply { print(this) }
}