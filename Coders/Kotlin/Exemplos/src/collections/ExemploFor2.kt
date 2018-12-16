package collections

fun main(args: Array<String>) {
    val alunos = arrayListOf("Flávio", "Fernando")
    alunos.withIndex().forEach { (index, value) ->
        println("${index + 1} $value")
    }
}