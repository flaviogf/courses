package lambdas

fun main(args: Array<String>) {
    val soma = { x: Int, y: Int -> x + y }
    print(soma(4, 5))
}