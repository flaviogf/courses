package visao

import modelo.Tabuleiro
import java.awt.GridLayout
import javax.swing.JPanel

class PainelTabuleiro(tabuleiro: Tabuleiro) : JPanel() {

    init {
        val (linhas, colunas) = tabuleiro
        layout = GridLayout(linhas, colunas)
        tabuleiro.forEachCampo {
            val botao = BotaoCampo(it)
            add(botao)
        }
    }
}