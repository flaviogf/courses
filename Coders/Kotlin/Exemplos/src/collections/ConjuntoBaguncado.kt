package collections

fun Any.print() = println(this)

fun main(args: Array<String>) {
    val set = hashSetOf(1, 1.2, 'a', "texto")
    set.add(1).print()
    set.add(2).print()
    set.contains(1.2).print()
    set.contains("a").print()
    set.size.print()
    set.withIndex().forEach { (indice, valor) -> println("$indice - $valor") }
    set.none { it == 'a' }.print()
    val novoSet = setOf(2, 3)
    set.intersect(novoSet).print()
    set.clear()
    set.print()
}
