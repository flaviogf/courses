package lambdas

data class Produto(val nome: String, val preco: Double)

fun main(args: Array<String>) {
    val produtos = arrayListOf(
            Produto("Borracha", 1.50),
            Produto("Lapis", 0.75),
            Produto("Caneta", 1.50)
    )
    val totalizar = { total: Double, atual: Double -> total + atual }
    produtos.map { it.preco }.reduce(totalizar).apply { println(this) }
}