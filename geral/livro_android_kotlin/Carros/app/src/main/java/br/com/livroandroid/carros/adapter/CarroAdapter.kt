package br.com.livroandroid.carros.adapter

import android.support.v7.widget.RecyclerView
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import br.com.livroandroid.carros.R
import br.com.livroandroid.carros.domain.Carro
import br.com.livroandroid.carros.extensions.loadUrl
import kotlinx.android.synthetic.main.adapter_carro.view.*

class CarroAdapter(
        private val carros: List<Carro>,
        private val onClick: (Carro) -> Unit) : RecyclerView.Adapter<CarroAdapter.CarroViewHolder>() {

    class CarroViewHolder(view: View) : RecyclerView.ViewHolder(view)

    override fun onCreateViewHolder(parent: ViewGroup?, viewType: Int): CarroViewHolder {
        val view = LayoutInflater.from(parent?.context).inflate(R.layout.adapter_carro, parent, false)
        return CarroViewHolder(view)
    }

    override fun onBindViewHolder(holder: CarroViewHolder?, position: Int) {
        val carro = carros[position]
        holder?.apply {
            with(itemView) {
                adapter_carro_nome.text = carro.nome
                adapter_carro_foto.loadUrl(carro.urlFoto, adapter_carro_progress)
                setOnClickListener { onClick(carro) }
            }
        }
    }

    override fun getItemCount() = this.carros.size
}