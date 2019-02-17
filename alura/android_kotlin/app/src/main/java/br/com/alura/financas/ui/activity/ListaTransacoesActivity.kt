package br.com.alura.financas.ui.activity

import android.content.Context
import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import android.view.ViewGroup
import android.widget.AdapterView
import br.com.alura.financas.R
import br.com.alura.financas.dao.TransacaoDao
import br.com.alura.financas.dialog.AdicionaTransacaoDialog
import br.com.alura.financas.dialog.AlteraTransacaoDialog
import br.com.alura.financas.model.Tipo
import br.com.alura.financas.model.Transacao
import br.com.alura.financas.ui.ResumoView
import br.com.alura.financas.ui.adapter.ListaTransacoesAdapter
import kotlinx.android.synthetic.main.activity_lista_transacoes.*

class ListaTransacoesActivity : AppCompatActivity() {

    //private lateinit var viewActivity: View
    private val dao = TransacaoDao()
    private val transacoes = dao.transcaoes
    private val context: Context = this
    private val viewActivity by lazy {
        window.decorView
    }
    private val viewGroupActivity by lazy {
        viewActivity as ViewGroup
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_lista_transacoes)
        //viewActivity = window.decorView
        atualizaTransacoes()
        configuraFab()
    }

    private fun atualizaTransacoes() {
        configuraLista()
        configuraResumo()
    }

    private fun configuraResumo() {
        ResumoView(context, viewActivity, transacoes).atualiza()
    }

    private fun configuraLista() {
        with(lista_transacoes_listview) {
            adapter = ListaTransacoesAdapter(transacoes, context)
            setOnItemClickListener { parent, _, posicao, _ ->
                val transacao = lista_transacoes_listview.getItemAtPosition(posicao) as Transacao
                AlteraTransacaoDialog(context, parent, transacao) {
                    alterar(it, posicao)
                    lista_transacoes_adiciona_menu.close(true)
                }
            }
            setOnCreateContextMenuListener { menu, _, _ ->
                menu.add("Remover").setOnMenuItemClickListener {
                    val adapterMenuInfo = it.menuInfo as AdapterView.AdapterContextMenuInfo
                    val posicaoTransacao = adapterMenuInfo.position
                    remover(posicaoTransacao)
                    true
                }
            }
        }
    }

    private fun configuraFab() {
        lista_transacoes_adiciona_receita.setOnClickListener {
            AdicionaTransacaoDialog(context, viewGroupActivity, Tipo.RECEITA) {
                adicionar(it)
                lista_transacoes_adiciona_menu.close(true)
            }
        }
        lista_transacoes_adiciona_despesa.setOnClickListener {
            AdicionaTransacaoDialog(context, viewGroupActivity, Tipo.DESPESA) {
                adicionar(it)
                lista_transacoes_adiciona_menu.close(true)
            }
        }
    }

    private fun adicionar(transacao: Transacao) {
        dao.adicionar(transacao)
        atualizaTransacoes()
    }

    private fun alterar(transacao: Transacao, posicao: Int) {
        dao.alterar(transacao, posicao)
        atualizaTransacoes()
    }

    private fun remover(posicao: Int) {
        dao.remover(posicao)
        atualizaTransacoes()
    }
}