package com.example.flavio.helloandroid

import android.os.Bundle
import android.support.v7.widget.SearchView
import android.support.v7.widget.Toolbar
import android.view.Menu
import android.view.MenuItem
import android.widget.TextView
import com.example.flavio.helloandroid.extensions.toast

class BemVindoActivity : DebugActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_bem_vindo)
        val toolbar = findViewById<Toolbar>(R.id.toolbar)
        setSupportActionBar(toolbar)
        supportActionBar?.setDisplayHomeAsUpEnabled(true)
        val textViewMensagem = findViewById<TextView>(R.id.bem_vindo_text_view_mensagem)
        val args = intent.extras
        val nome = args.getString("nome")
        textViewMensagem.text = "Bem vindo $nome"
    }

    override fun onCreateOptionsMenu(menu: Menu?): Boolean {
        menuInflater.inflate(R.menu.menu_bem_vindo, menu)
        val itemSearch = menu?.findItem(R.id.menu_bem_vindo_search)
        val viewSearch = itemSearch?.actionView as SearchView
        viewSearch.setOnQueryTextListener(onQueryTextListener())
        return super.onCreateOptionsMenu(menu)
    }

    override fun onOptionsItemSelected(item: MenuItem?): Boolean {
        when (item?.itemId) {
            android.R.id.home -> finish()
            R.id.menu_bem_vindo_search -> toast("Procurar")
            R.id.menu_bem_vindo_atualizar -> toast("Atualizar")
            R.id.menu_bem_vindo_configuracoes -> toast("Configurações")
        }
        return super.onOptionsItemSelected(item)
    }

    private fun onQueryTextListener(): SearchView.OnQueryTextListener {
        return object : SearchView.OnQueryTextListener {
            override fun onQueryTextSubmit(query: String?): Boolean {
                toast(query ?: "Nenhum texto")
                return false
            }

            override fun onQueryTextChange(texto: String?): Boolean {
                return false
            }
        }
    }
}