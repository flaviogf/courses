package collections

fun main(args: Array<String>) {
    val aprovados = hashSetOf("Fatima", "Flavio", "Luis Fernando", "Fernando")
    println("Sem ordem...")
    for (aprovado in aprovados) {
        aprovado.print()
    }
    val aprovadosOrdem1 = linkedSetOf("Fatima", "Flavio", "Luis Fernando", "Fernando")
    println("\nOrdenados por ordem de inserção...")
    for (aprovado in aprovadosOrdem1) {
        aprovado.print()
    }
    val aprovadosOrdem2 = sortedSetOf("Fatima", "Flavio", "Luis Fernando", "Fernando")
    println("\nOrdenandos por ordem alfabetica/maior para menor")
    for (aprovado in aprovadosOrdem2) {
        aprovado.print()
    }
    println("\nSet sem ordem sendo ordenado por um critério")
    aprovados.sortedBy { it.substring(1) }.print()
}