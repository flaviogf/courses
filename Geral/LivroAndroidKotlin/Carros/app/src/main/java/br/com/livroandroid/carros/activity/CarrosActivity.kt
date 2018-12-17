package br.com.livroandroid.carros.activity

import android.os.Bundle
import br.com.livroandroid.carros.R
import br.com.livroandroid.carros.domain.TipoCarro
import br.com.livroandroid.carros.extensions.addFragment
import br.com.livroandroid.carros.extensions.setupToolbar
import br.com.livroandroid.carros.fragments.CarrosFragment

class CarrosActivity : BaseActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_carros)
        val tipo = intent.getSerializableExtra("tipo") as TipoCarro
        val title = getString(tipo.string)
        setupToolbar(R.id.toolbar, title, true)
        if (savedInstanceState == null) {
            addFragment(R.id.container, CarrosFragment())
        }
    }
}