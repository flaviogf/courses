package collections

fun main(args: Array<String>) {
    val numeros = arrayListOf("Flávio", "Fernando")
    val strings = arrayListOf(1, 2)
    val uniao = numeros + strings
    for (item in uniao) {
        println(item)
    }
}