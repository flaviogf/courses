package br.com.livroandroid.carros.extensions

import org.w3c.dom.Element
import org.w3c.dom.Node

class Xlm(val root: Element) {

    fun getChildren(nome: String): List<Node> {
        return getChildren(root, nome)
    }

    fun getChildren(node: Element = root, nome: String): List<Node> {
        val children = ArrayList<Node>()
        val nodes = node.childNodes
        nodes?.takeIf { it.length >= 1 }?.also {
            for (i in 0 until it.length) {
                val item = nodes.item(i)
                item?.takeIf { it.nodeName == nome }?.also { children.add(it) }
            }
        }
        return children
    }
}

fun Node.getChild(tag: String): Node? {
    val nodeList = childNodes ?: return null
    for (i in 0 until nodeList.length) {
        val item = nodeList.item(i)
        return item?.takeIf { it.nodeName.equals(tag, ignoreCase = true) }
    }
    return null
}
