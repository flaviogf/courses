package flaviogf.cursorecyclerviewalura.ui.recyclerview

import android.support.v7.widget.RecyclerView
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import flaviogf.cursorecyclerviewalura.R
import flaviogf.cursorecyclerviewalura.model.Nota
import kotlinx.android.synthetic.main.item_lista_notas.view.*


class NotaAdapter(private val notas: MutableList<Nota>) : RecyclerView.Adapter<NotaAdapter.NotaViewHolder>() {

    class NotaViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

        private val descricao = itemView.item_nota_descricao
        private val titulo = itemView.item_nota_titulo

        fun vincula(nota: Nota) {
            descricao.text = nota.descricao
            titulo.text = nota.titulo
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): NotaViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.item_lista_notas, parent, false)
        return NotaViewHolder(view)
    }

    override fun onBindViewHolder(holder: NotaViewHolder, position: Int) {
        val nota = notas[position]
        holder.vincula(nota)
    }

    override fun getItemCount() = notas.count()

    fun adiciona(nota: Nota) {
        notas.add(nota)
        notifyDataSetChanged()
    }
}
