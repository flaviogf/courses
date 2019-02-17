package br.com.alura.financas.dao

import br.com.alura.financas.model.Transacao

class TransacaoDao {

    companion object {
        private val transacoes: MutableList<Transacao> = mutableListOf()
    }

    val transcaoes: List<Transacao> = Companion.transacoes

    fun adicionar(transacao: Transacao) {
        Companion.transacoes.add(transacao)
    }

    fun remover(posicao: Int) {
        Companion.transacoes.removeAt(posicao)
    }

    fun alterar(transacao: Transacao, posicao: Int) {
        Companion.transacoes[posicao] = transacao
    }
}