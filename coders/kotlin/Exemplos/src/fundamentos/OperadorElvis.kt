package fundamentos

fun main(args: Array<String>) {
    val opcional: String? = null
    val valor = opcional ?: "Valor padrão"
    print(valor)
}