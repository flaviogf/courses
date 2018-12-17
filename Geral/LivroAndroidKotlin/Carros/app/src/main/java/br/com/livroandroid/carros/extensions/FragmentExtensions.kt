package br.com.livroandroid.carros.extensions

import android.support.v4.app.Fragment
import android.widget.Toast

fun Fragment.toast(mensagem: String, duracao: Int = Toast.LENGTH_SHORT) {
    Toast.makeText(activity, mensagem, duracao).show()
}
