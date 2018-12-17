package flaviogf.cursorecyclerviewalura.ui.activity

import android.content.Intent
import android.os.Bundle
import android.support.v7.app.AppCompatActivity
import android.view.Menu
import android.view.MenuItem
import flaviogf.cursorecyclerviewalura.R
import flaviogf.cursorecyclerviewalura.dao.NotaDao
import flaviogf.cursorecyclerviewalura.model.Nota
import kotlinx.android.synthetic.main.activity_formulario_adiciona_nota.*
import java.util.*

class FormularioAdicionaNotaActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_formulario_adiciona_nota)
    }

    override fun onCreateOptionsMenu(menu: Menu?): Boolean {
        menuInflater?.inflate(R.menu.menu_formulario_adiciona_nota, menu)
        return super.onCreateOptionsMenu(menu)
    }

    override fun onOptionsItemSelected(item: MenuItem?): Boolean {
        item?.itemId?.also { id ->
            when (id) {
                R.id.menu_adiciona_nota -> {
                    val nota = criaNota()
                    NotaDao.adiciona(nota)
                    criaResultadoNotaInserida(nota)
                    finish()
                }
            }
        }
        return super.onOptionsItemSelected(item)
    }

    private fun criaResultadoNotaInserida(nota: Nota) {
        val intent = Intent()
        intent.putExtra(CHAVE_NOTA, nota.id)
        setResult(CODIGO_RESULTADO_ADICIONAR_NOTA, intent)
    }

    private fun criaNota(): Nota = Nota(
            UUID.randomUUID(),
            formulario_nota_titulo.text.toString(),
            formulario_nota_descricao.text.toString()
    )
}
