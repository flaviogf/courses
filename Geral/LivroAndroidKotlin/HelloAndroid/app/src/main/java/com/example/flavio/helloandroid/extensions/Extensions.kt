package com.example.flavio.helloandroid.extensions

import android.app.Activity
import android.support.annotation.IdRes
import android.view.View
import android.widget.Button
import android.widget.TextView
import android.widget.Toast

fun Activity.getTextString(@IdRes viewId: Int): String {
    val textView = findViewById<TextView>(viewId)
    return textView.text.toString()
}

fun Activity.onClick(@IdRes viewId: Int, onClick: (view: View?) -> Unit) {
    val btn = findViewById<Button>(viewId)
    btn.setOnClickListener { onClick(it) }
}

fun Activity.toast(mensagem: String, duracao: Int = Toast.LENGTH_SHORT) {
    Toast.makeText(this, mensagem, duracao).show()
}