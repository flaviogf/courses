package flaviogf.cursorecyclerviewalura.dao

import flaviogf.cursorecyclerviewalura.model.Nota
import java.util.*

object NotaDao {

    private val notas = mutableListOf(
            Nota(UUID.randomUUID(), "Titulo 1", "Descrição 1"),
            Nota(UUID.randomUUID(), "Titulo 2", "Descrição 2")
    )

    fun adiciona(nota: Nota) = notas.add(nota)

    fun lista() = notas.toMutableList()

    fun buscaPor(id: UUID) = notas.firstOrNull { it.id == id }
}
