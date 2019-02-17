package collections

fun main(args: Array<String>) {
    val matriz = Array(3) { arrayOfNulls<Int>(3) }
    matriz[0][0] = 1
    matriz[0][1] = 2
    matriz[0][2] = 3
    matriz[1][0] = 4
    matriz[1][1] = 5
    matriz[1][2] = 6
    matriz[2][0] = 7
    matriz[2][1] = 8
    matriz[2][2] = 9

    matriz.forEach {
        it.forEach {
            println(it)
        }
    }
}