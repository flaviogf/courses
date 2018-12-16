package fundamentos.controles

fun main(args: Array<String>) {
    var listaAlunos = arrayListOf("flavio", "fernando", "fatima")
    for ((indice, aluno) in listaAlunos.withIndex()) {
        println("${indice + 1} - $aluno")
    }
}