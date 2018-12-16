package br.com.alura.financas.dialog

import android.app.AlertDialog
import android.app.DatePickerDialog
import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.EditText
import android.widget.Spinner
import br.com.alura.financas.R
import br.com.alura.financas.extension.converteParaBigDecimal
import br.com.alura.financas.extension.converterParaData
import br.com.alura.financas.extension.extrairDataAtual
import br.com.alura.financas.extension.formataParaBrasileiro
import br.com.alura.financas.model.Tipo
import br.com.alura.financas.model.Transacao
import kotlinx.android.synthetic.main.form_transacao.view.*
import java.util.*

abstract class FormularioTransacaoDialog(
        private val context: Context,
        private val tipo: Tipo,
        private val viewGroup: ViewGroup,
        private val delegate: (Transacao) -> Unit) {

    private val viewCriada: View = criaView()
    val campoValor: EditText = viewCriada.form_transacao_valor
    val campoData: EditText = viewCriada.form_transacao_data
    val campoCategoria: Spinner = viewCriada.form_transacao_categoria

    open protected fun configuraDialog() {
        configuraCampoData()
        configuraCampoCategoria()
        configuraAlert()
    }

    private fun configuraAlert() {
        val titulo = tituloPorTipo()
        AlertDialog.Builder(context)
                .setTitle(titulo)
                .setView(viewCriada)
                .setNegativeButton("CANCELAR", null)
                .setPositiveButton("CONFIRMAR") { _, _ ->
                    val valorEmTexto = campoValor.text.toString()
                    val dataEmTexto = campoData.text.toString()
                    val categoria = campoCategoria.selectedItem.toString()
                    val valor = valorEmTexto.converteParaBigDecimal()
                    val data = dataEmTexto.converterParaData()
                    val transacao = Transacao(
                            valor = valor,
                            categoria = categoria,
                            tipo = tipo,
                            data = data
                    )
                    delegate(transacao)
                }
                .show()
    }

    private fun configuraCampoData() {
        val dataAtual = Calendar.getInstance()
        val (dia, mes, ano) = dataAtual.extrairDataAtual()
        campoData.setText(dataAtual.formataParaBrasileiro())
        campoData.setOnClickListener {
            DatePickerDialog(context, { _, ano, mes, dia ->
                val dataSelecionada = Calendar.getInstance()
                dataSelecionada.set(ano, mes, dia)
                campoData.setText(dataSelecionada.formataParaBrasileiro())
            }, ano, mes, dia).show()
        }
    }

    private fun configuraCampoCategoria() {
        val categorias = categoriasPorTipo()
        val adapter = ArrayAdapter.createFromResource(context, categorias, android.R.layout.simple_spinner_dropdown_item)
        campoCategoria.adapter = adapter
    }

    private fun criaView(): View {
        return LayoutInflater.from(context).inflate(R.layout.form_transacao, viewGroup, false)
    }

    private fun categoriasPorTipo() =
            if (tipo == Tipo.RECEITA)
                R.array.categorias_de_receita
            else
                R.array.categorias_de_despesa

    abstract fun tituloPorTipo(): Int
//            if (tipo == Tipo.RECEITA)
//                R.string.adiciona_receita
//            else
//                R.string.adiciona_despesa
}