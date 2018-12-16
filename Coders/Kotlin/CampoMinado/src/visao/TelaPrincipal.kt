package visao

import modelo.Tabuleiro
import modelo.TabuleiroEvento
import javax.swing.JFrame
import javax.swing.JOptionPane
import javax.swing.SwingUtilities

fun main(args: Array<String>) {
    TelaPrincipal()
}

class TelaPrincipal : JFrame() {

    private val tabuleiro = Tabuleiro(qtdLinhas = 16, qtdColunas = 30, qtdMinas = 10)
    private val painelTabuleiro = PainelTabuleiro(tabuleiro)

    init {
        tabuleiro.onEvento {
            SwingUtilities.invokeLater {
                val msg = when (it) {
                    TabuleiroEvento.VITORIA -> "Você Ganhou!"
                    else -> "Você Perdeu... :P"
                }
                JOptionPane.showMessageDialog(this, msg)
                tabuleiro.reiniciar()
                painelTabuleiro.repaint()
                painelTabuleiro.validate()
            }
        }

        add(painelTabuleiro)
        setSize(690, 438)
        setLocationRelativeTo(null)
        defaultCloseOperation = EXIT_ON_CLOSE
        title = "Campo Minado"
        isVisible = true
    }
}