package br.com.livroandroid.carros.activity

import android.os.Bundle
import android.support.design.widget.Snackbar
import android.support.v4.content.ContextCompat
import android.support.v7.app.ActionBarDrawerToggle
import android.view.Gravity
import br.com.livroandroid.carros.R
import br.com.livroandroid.carros.adapter.TabsAdapter
import br.com.livroandroid.carros.domain.TipoCarro
import br.com.livroandroid.carros.extensions.setupToolbar
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.toolbar.*
import org.jetbrains.anko.startActivity
import org.jetbrains.anko.toast

class MainActivity : BaseActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        setup()
        fab.setOnClickListener {
            Snackbar.make(it, "Clicou no botão FAB", Snackbar.LENGTH_SHORT).show()
        }
    }

    private fun setup() {
        setupToolbar(R.layout.toolbar)
        setupNavDrawer()
        setupTabs()
    }

    private fun setupTabs() {
        activity_main_view_pager.adapter = TabsAdapter(context, supportFragmentManager)
        val cor = ContextCompat.getColor(context, R.color.white)
        activity_main_tab_layout.setupWithViewPager(activity_main_view_pager)
        activity_main_tab_layout.setTabTextColors(cor, cor)
    }

    private fun setupNavDrawer() {
        val toggle = ActionBarDrawerToggle(
                this,
                drawer_layout,
                toolbar,
                R.string.navigation_drawer_open,
                R.string.navigation_drawer_close
        )
        drawer_layout.addDrawerListener(toggle)
        toggle.syncState()
        nav_view.setNavigationItemSelectedListener {
            when (it.itemId) {
                R.id.nav_item_carros_todos -> {
                    toast("Todos carros")
                }
                R.id.nav_item_carros_classicos -> {
                    startActivity<CarrosActivity>("tipo" to TipoCarro.Classicos)
                }
                R.id.nav_item_carros_esportivos -> {
                    startActivity<CarrosActivity>("tipo" to TipoCarro.Esportivos)
                }
                R.id.nav_item_carros_luxo -> {
                    startActivity<CarrosActivity>("tipo" to TipoCarro.Luxo)
                }
                R.id.nav_item_site_livro -> {
                    startActivity<SiteLivroActivity>()
                }
                R.id.nav_item_settings -> {
                    toast("Configurações")
                }
            }
            drawer_layout.closeDrawer(Gravity.START)
            true
        }
    }
}
