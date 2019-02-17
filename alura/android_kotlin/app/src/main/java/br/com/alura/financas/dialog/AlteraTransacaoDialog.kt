package br.com.alura.financas.dialog

import android.content.Context
import android.view.ViewGroup
import br.com.alura.financas.R
import br.com.alura.financas.extension.formataParaBrasileiro
import br.com.alura.financas.model.Tipo
import br.com.alura.financas.model.Transacao

class AlteraTransacaoDialog(
        private val context: Context,
        viewGroup: ViewGroup,
        private val transacao: Transacao,
        delegate: (transacao: Transacao) -> Unit) : FormularioTransacaoDialog(context, transacao.tipo, viewGroup, delegate) {

    init {
        configuraDialog()
    }

    override fun configuraDialog() {
        super.configuraDialog()
        inicializaCampos()
    }

    private fun inicializaCampos() {
        incializaCampoValor()
        inicializaCampoData()
        inicializaCampoCategoria()
    }

    private fun inicializaCampoCategoria() {
        val categorias = if (transacao.tipo == Tipo.RECEITA) {
            context.resources.getStringArray(R.array.categorias_de_receita)
        } else {
            context.resources.getStringArray(R.array.categorias_de_despesa)
        }
        val categoria = categorias.indexOf(transacao.categoria)
        campoCategoria.setSelection(categoria)
    }

    private fun inicializaCampoData() {
        campoData.setText(transacao.data.formataParaBrasileiro())
    }

    private fun incializaCampoValor() {
        campoValor.setText(transacao.valor.toString())
    }

    override fun tituloPorTipo() =
            if (transacao.tipo == Tipo.RECEITA)
                R.string.altera_receita
            else
                R.string.altera_despesa
}