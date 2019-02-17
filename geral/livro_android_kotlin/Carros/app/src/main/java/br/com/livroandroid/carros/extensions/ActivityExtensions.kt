package br.com.livroandroid.carros.extensions

import android.support.annotation.IdRes
import android.support.v4.app.Fragment
import android.support.v7.app.ActionBar
import android.support.v7.app.AppCompatActivity
import android.support.v7.widget.Toolbar

fun AppCompatActivity.setupToolbar(@IdRes id: Int, titulo: String? = null, upNavigation: Boolean = false): ActionBar? {
    val toolbar = findViewById<Toolbar>(id)
    setSupportActionBar(toolbar)
    supportActionBar?.setDisplayHomeAsUpEnabled(upNavigation)
    if (titulo != null) {
        supportActionBar?.title = titulo
    }
    return supportActionBar
}

fun AppCompatActivity.addFragment(@IdRes layoutId: Int, fragment: Fragment) {
    fragment.arguments = intent.extras
    val fragmentTransaction = supportFragmentManager.beginTransaction()
    fragmentTransaction.add(layoutId, fragment)
    fragmentTransaction.commit()
}