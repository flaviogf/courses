package com.example.flavio.helloandroid

import android.content.Intent
import android.os.Bundle
import com.example.flavio.helloandroid.extensions.getTextString
import com.example.flavio.helloandroid.extensions.onClick
import com.example.flavio.helloandroid.extensions.toast

class MainActivity : DebugActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        onClick(R.id.main_button_login) { onClickLogin() }
    }

    private fun onClickLogin() {
        val usuario = getTextString(R.id.main_edit_text_usuario)
        val senha = getTextString(R.id.main_edit_text_senha)
        if (usuario == "flavio" && senha == "123") {
            toast("Bem vindo, login realizado com sucesso")
            val intent = Intent(this, BemVindoActivity::class.java)
            val params = Bundle()
            params.putString("nome", usuario)
            intent.putExtras(params)
            startActivity(intent)
            return
        }
        toast("Usuário ou senha inválidos")
    }
}
