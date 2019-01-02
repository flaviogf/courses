package capitulo2.propriedades

class Retangulo(private val altura: Int, private val largura: Int) {

    val isQuadrado get() = altura == largura

    val area get() = altura * largura
}

fun main(args: Array<String>) {
    val retangulo = Retangulo(100, 100)
    println(retangulo.isQuadrado)
    println(retangulo.area)
}
