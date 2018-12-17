package br.com.livroandroid.carros.domain

import android.content.Context
import android.util.Log
import br.com.livroandroid.carros.R

object CarroService {

    fun getCarros(context: Context, tipo: TipoCarro): List<Carro> {
        context.resources.openRawResource(R.raw.carros_classicos).bufferedReader().use {
            val text = it.readText()
            Log.d("Carros", text)
        }
        val tipoString = context.getString(tipo.string)
        val carros = mutableListOf<Carro>()
        for (i in 1..20) {
            val nome = "Carro $tipoString $i"
            carros.add(Carro(
                    id = i.toLong(),
                    nome = nome,
                    desc = "Descrição $nome",
                    urlFoto = "http://www.livroandroid.com.br/livro/carros/esportivos/Ferrari_FF.png"
            ))
        }
        return carros
    }
}