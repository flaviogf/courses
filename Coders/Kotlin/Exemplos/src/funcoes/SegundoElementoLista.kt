package funcoes

fun <E> List<E>.secondOrNull(): E? = if (this.size >= 2) this[1] else null

fun main(args: Array<String>) {
    val alunos = listOf("Flavio", "Fernando")
    println(alunos.secondOrNull())
}