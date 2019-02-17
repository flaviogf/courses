package funcoes

fun <E> filtrar(lista: List<E>, filtro: (E) -> Boolean): List<E> {
    val listaFiltrada = ArrayList<E>()
    for (item in lista) {
        if (filtro(item)) {
            listaFiltrada.add(item)
        }
    }
    return listaFiltrada
}

fun nomeComTresLetras(item: String): Boolean = item.length == 3

fun main(args: Array<String>) {
    val nomes = listOf("Ana", "Flávio", "Zé", "Fernando")
    println(filtrar(nomes, ::nomeComTresLetras))
}