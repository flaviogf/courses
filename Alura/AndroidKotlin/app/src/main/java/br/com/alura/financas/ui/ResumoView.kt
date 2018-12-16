package br.com.alura.financas.ui

import android.content.Context
import android.support.v4.content.ContextCompat
import android.view.View
import br.com.alura.financas.R
import br.com.alura.financas.extension.formataParaBrasileiro
import br.com.alura.financas.model.Resumo
import br.com.alura.financas.model.Transacao
import kotlinx.android.synthetic.main.resumo_card.view.*
import java.math.BigDecimal

class ResumoView(context: Context,
                 private val view: View,
                 transacoes: List<Transacao>) {

    private val resumo: Resumo = Resumo(transacoes)
    private val corReceita: Int = ContextCompat.getColor(context, R.color.receita)
    private val corDespesa: Int = ContextCompat.getColor(context, R.color.despesa)

    fun atualiza() {
        adicionarReceita()
        adicionaDespesa()
        adicionaTotal()
    }

    private fun adicionarReceita() {
        with(view.resumo_card_receita) {
            setTextColor(corReceita)
            text = resumo.receita.formataParaBrasileiro()
        }
    }

    private fun adicionaDespesa() {
        with(view.resumo_card_despesa) {
            setTextColor(corDespesa)
            text = resumo.despesa.formataParaBrasileiro()
        }
    }

    private fun adicionaTotal() {
        val total = resumo.total
        val cor = corTotal(total)
        with(view.resumo_card_total) {
            setTextColor(cor)
            text = total.formataParaBrasileiro()
        }
    }

    private fun corTotal(total: BigDecimal): Int {
        if (total >= BigDecimal.ZERO) {
            return corReceita
        }
        return corDespesa
    }
}