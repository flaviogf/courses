package br.com.livroandroid.carros.activity

import android.os.Bundle
import br.com.livroandroid.carros.R
import br.com.livroandroid.carros.domain.Carro
import br.com.livroandroid.carros.extensions.loadUrl
import br.com.livroandroid.carros.extensions.setupToolbar
import kotlinx.android.synthetic.main.activity_carro.*
import kotlinx.android.synthetic.main.activity_carro_content.*

class CarroActivity : BaseActivity() {

    private val carro by lazy {
        intent.getParcelableExtra<Carro>("carro")
    }

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_carro)
        setupToolbar(R.id.toolbar_carro, carro.nome, true)
        inicializaView()
    }

    private fun inicializaView() {
        activity_carro_descricao.text = carro.desc
        app_bar_img.loadUrl(carro.urlFoto)
    }
}