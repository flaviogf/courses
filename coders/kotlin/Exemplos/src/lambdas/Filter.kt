package lambdas

data class Aluno(val nome: String, val nota: Double)

fun main(args: Array<String>) {
    val alunos = arrayListOf(
            Aluno("Flavio", 10.0),
            Aluno("Fatima", 9.5),
            Aluno("Fernando", 5.7)
    )
    val aprovados = alunos.filter { it.nota > 7.0 }.sortedBy { it.nome }
    println(aprovados)
}