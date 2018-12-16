package funcoes

class Produto(val nome: String, var preco: Double)

infix fun Produto.maisCaroQue(produto: Produto): Boolean = this.preco > produto.preco

infix fun Produto.someCom(produto: Produto) {
    this.preco = this.preco + produto.preco
}

fun main(args: Array<String>) {
    val prod1 = Produto("Ipad", 3000.00)
    val prod2 = Produto(preco = 3.50, nome = "Borracha")
    println(prod1.maisCaroQue(prod2))
    println(prod2 maisCaroQue prod1)
    prod1 someCom prod2
    println(prod1.preco)
}