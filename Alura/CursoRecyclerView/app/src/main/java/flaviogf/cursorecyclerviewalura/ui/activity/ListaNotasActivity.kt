package flaviogf.cursorecyclerviewalura.ui.activity

import android.content.Intent
import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import flaviogf.cursorecyclerviewalura.R
import flaviogf.cursorecyclerviewalura.dao.NotaDao
import flaviogf.cursorecyclerviewalura.model.Nota
import flaviogf.cursorecyclerviewalura.ui.recyclerview.NotaAdapter
import kotlinx.android.synthetic.main.activity_lista_notas.*
import java.util.*

class ListaNotasActivity : AppCompatActivity() {

    private lateinit var notaAdapter: NotaAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_lista_notas)
        configuraAdapter()
        configuraFab()
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        if (requestCode == CODIGO_REQUISICAO_ADICIONAR_NOTA && resultCode == CODIGO_RESULTADO_ADICIONAR_NOTA) {
            atualizaNotas(data)
        }
        super.onActivityResult(requestCode, resultCode, data)
    }

    private fun configuraAdapter() {
        val notas = NotaDao.lista()
        notaAdapter = NotaAdapter(notas)
        lista_figurinhas.adapter = notaAdapter
    }

    private fun configuraFab() {
        lista_fab_insere_nota.setOnClickListener {
            val intent = Intent(this, FormularioAdicionaNotaActivity::class.java)
            startActivityForResult(intent, CODIGO_REQUISICAO_ADICIONAR_NOTA)
        }
    }

    private fun atualizaNotas(data: Intent?) {
        data?.takeIf {
            it.hasExtra(CHAVE_NOTA)
        }?.apply {
            val id = getSerializableExtra(CHAVE_NOTA) as UUID
            val nota = NotaDao.buscaPor(id)
            nota?.also {
                adiciona(it)
            }
        }
    }

    private fun adiciona(nota: Nota) {
        notaAdapter.adiciona(nota)
    }
}
