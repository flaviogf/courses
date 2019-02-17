@file:JvmName("StringUtils")

package capitulo3.colecoes

@JvmOverloads
fun <T> joinToString(collection: Collection<T>, separator: String = ",", prefix: String = "", postfix: String = ""): String {
    val builder = StringBuilder()
    builder.append(prefix)
    for ((index, item) in collection.withIndex()) {
        if (index > 0) builder.append(separator)
        builder.append(item)
    }
    builder.append(postfix)
    return builder.toString()
}

@JvmOverloads
@JvmName("colecaoJoinToString")
fun <T> Collection<T>.joinToString(separator: String = ",", prefix: String = "", postfix: String = ""): String {
    val builder = StringBuilder()
    builder.append(prefix)
    for ((index, item) in withIndex()) {
        if (index > 0) builder.append(separator)
        builder.append(item)
    }
    builder.append(postfix)
    return builder.toString()
}

fun String.lastChar() = get(length - 1)

val String.lastChar: Char
    get() = get(length - 1)


open class View {
    open fun click() = println("clique view")
}

class Button : View() {
    override fun click() = println("clique button")
}

fun View.show() = println("show view")

fun Button.show() = println("show button")

fun converteCaminhoSemRegex(caminho: String) {
    val diretorio = caminho.substringBeforeLast("\\")
    val caminhoArquivo = caminho.substringAfterLast("\\")
    val nomeArquivo = caminhoArquivo.substringBeforeLast(".")
    val extensao = caminhoArquivo.substringAfterLast(".")
    println("Diretorio $diretorio, nome: $nomeArquivo, extensao: $extensao")
}

fun converteCaminhoComRegex(caminho: String) {
    val regex = """(.+)\\(.+)\.(.+)""".toRegex()
    val matchEntire = regex.matchEntire(caminho)
    if (matchEntire != null) {
        val (diretorio, nome, extensao) = matchEntire.destructured
        println("Diretorio: $diretorio, nome: $nome, extensao: $extensao")
    }
}

fun main(args: Array<String>) {
    val set = setOf("1", "2")
    println(set.javaClass)
    val list = arrayListOf(1, 2, 3)
    println(list.javaClass)
    println(set.last())
    println(list.max())
    println(joinToString(set, ";", "(", ")"))
    println(joinToString(list, separator = ";", prefix = "(", postfix = ")"))
    println(joinToString(list))
    println("Flávio".lastChar())
    println(set.joinToString())
    println("Flávio".lastChar)
    val view: View = Button()
    view.click()
    view.show()
    val map = mapOf(1 to "um", 2 to "dois")
    val (numero, valor) = 1 to "um"
    println(numero.toString() + valor)
    converteCaminhoSemRegex("C:\\teste\\teste\\teste.txt")
    converteCaminhoComRegex("C:\\teste\\teste\\teste.txt")
    println(map)
}
