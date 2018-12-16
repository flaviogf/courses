package collections

fun main(args: Array<String>) {
    val alunos = arrayListOf("Flávio", "Fernando")
    for ((indice, aluno) in alunos.withIndex()) {
        println("${indice + 1} - $aluno")
    }
}