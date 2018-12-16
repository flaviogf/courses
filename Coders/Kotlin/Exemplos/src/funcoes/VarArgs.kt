package funcoes

fun ordernar(vararg numeros: Int): IntArray {
    return numeros.sortedArray()
}

fun main(args: Array<String>) {
    for (n in ordernar(10, 1, 9, 25, 30, 7)) {
        print("$n ")
    }
}