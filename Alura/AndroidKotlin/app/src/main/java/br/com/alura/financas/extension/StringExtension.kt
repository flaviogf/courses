package br.com.alura.financas.extension

import java.math.BigDecimal
import java.text.SimpleDateFormat
import java.util.*

fun String.limitaEmAte(caracteres: Int): String {
    if (this.length > caracteres) {
        val primeiroCaracter = 0
        return "${this.substring(primeiroCaracter, caracteres)}..."
    }
    return this
}

fun String.converterParaData(): Calendar {
    val formatoBrasileiro = SimpleDateFormat("dd/MM/yyyy")
    val dataConvertida = formatoBrasileiro.parse(this)
    val data = Calendar.getInstance()
    data.time = dataConvertida
    return data
}

fun String.converteParaBigDecimal(): BigDecimal {
    return try {
        BigDecimal(this)
    } catch (e: NumberFormatException) {
        BigDecimal.ZERO
    }
}