package fundamentos

fun main(args: Array<String>) {
    val a: Int? = null
    println(a?.inc())
    println("Momento da excecao")
    println(a!!.inc())
}