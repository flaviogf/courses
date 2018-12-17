package br.com.livroandroid.carros.extensions

import android.view.View
import android.widget.ImageView
import android.widget.ProgressBar
import com.squareup.picasso.Callback
import com.squareup.picasso.Picasso

fun ImageView.loadUrl(url: String, progressBar: ProgressBar? = null) {
    if (progressBar == null) {
        Picasso.with(context).load(url).fit().into(this)
        return
    }
    progressBar.visibility = View.VISIBLE
    Picasso.with(context).load(url).fit().into(this, object : Callback {
        override fun onSuccess() {
            progressBar.visibility = View.GONE
        }

        override fun onError() {
            progressBar.visibility = View.GONE
        }
    })
}
