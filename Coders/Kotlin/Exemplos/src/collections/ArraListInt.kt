package collections

fun main(args: Array<String>) {
    val impares = arrayListOf(1, 3, 5)
    val pares = intArrayOf(2, 4, 6)
    for (n in pares.union(impares).sorted()) {
        print("$n ")
    }
}