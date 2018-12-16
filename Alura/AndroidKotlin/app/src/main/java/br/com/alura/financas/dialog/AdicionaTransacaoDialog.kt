package br.com.alura.financas.dialog

import android.content.Context
import android.view.ViewGroup
import br.com.alura.financas.R
import br.com.alura.financas.model.Tipo
import br.com.alura.financas.model.Transacao

class AdicionaTransacaoDialog(
        context: Context,
        viewGroup: ViewGroup,
        private val tipo: Tipo,
        delegate: (transacao: Transacao) -> Unit) : FormularioTransacaoDialog(context, tipo, viewGroup, delegate) {

    init {
        super.configuraDialog()
    }

    override fun tituloPorTipo() =
            if (tipo === Tipo.RECEITA)
                R.string.adiciona_receita
            else
                R.string.adiciona_despesa
}