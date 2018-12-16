package collections

fun main(args: Array<String>) {
    val map = hashMapOf(1 to "Flávio", 2 to "Fernando")
    for (nome in map.values.sorted()) {
        println(nome)
    }
}