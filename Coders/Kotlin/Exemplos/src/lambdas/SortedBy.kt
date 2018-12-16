package lambdas

fun main(args: Array<String>) {
    val nomes = arrayListOf("Flávio", "Luis", "Fatima", "Fernando")
    val ordenados = nomes.sortedBy { it }
    val ordenadosDec = nomes.sortedBy { it.reversed() }
    println(ordenados)
    println(ordenadosDec)
}