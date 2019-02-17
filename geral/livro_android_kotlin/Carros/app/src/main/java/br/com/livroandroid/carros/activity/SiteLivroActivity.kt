package br.com.livroandroid.carros.activity

import android.graphics.Bitmap
import android.os.Bundle
import android.view.View
import android.webkit.WebResourceRequest
import android.webkit.WebView
import android.webkit.WebViewClient
import br.com.livroandroid.carros.R
import br.com.livroandroid.carros.dialog.AboutDialog
import br.com.livroandroid.carros.extensions.setupToolbar
import kotlinx.android.synthetic.main.activity_site_livro.*

class SiteLivroActivity : BaseActivity() {

    val url: String = "http://www.livroandroid.com.br/sobre.htm"

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_site_livro)
        setupToolbar(id = R.id.toolbar, upNavigation = true)
        site_swipe_refresh.setOnRefreshListener { site_web_view.reload() }
        site_swipe_refresh.setColorSchemeResources(
                R.color.refresh_progress_1,
                R.color.refresh_progress_2,
                R.color.refresh_progress_3
        )
        site_web_view.webViewClient = object : WebViewClient() {
            override fun onPageStarted(view: WebView?, url: String?, favicon: Bitmap?) {
                super.onPageStarted(view, url, favicon)
                site_progress_bar.visibility = View.VISIBLE
            }

            override fun onPageFinished(view: WebView?, url: String?) {
                super.onPageFinished(view, url)
                site_progress_bar.visibility = View.INVISIBLE
                site_swipe_refresh.isRefreshing = false
            }

            override fun shouldOverrideUrlLoading(view: WebView?, request: WebResourceRequest?): Boolean {
                val url = request?.url.toString()
                if (url.endsWith("sobre.htm")) {
                    AboutDialog.showAbout(supportFragmentManager)
                    return true
                }
                return super.shouldOverrideUrlLoading(view, request)
            }
        }
        site_web_view.loadUrl(url)
    }
}