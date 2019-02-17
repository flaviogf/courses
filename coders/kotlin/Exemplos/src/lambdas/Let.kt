package lambdas

fun main(args: Array<String>) {
    val nomes = arrayListOf("Flávio", null, "Fernando", null)
    for (item in nomes) {
        item?.let {
            println(it)
        }
    }
}