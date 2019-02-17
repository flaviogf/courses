package funcoes

fun min(a: Int, b: Int) = if (a > b) b else a

fun main(args: Array<String>) {
    println("O menor numero é ${min(10, 7)}")
}