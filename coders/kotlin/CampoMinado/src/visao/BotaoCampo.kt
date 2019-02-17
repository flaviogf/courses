package visao

import modelo.Campo
import modelo.CampoEvento
import java.awt.Color
import java.awt.Font
import javax.swing.BorderFactory
import javax.swing.JButton
import javax.swing.SwingUtilities

enum class CoresCampo(val valor: Color) {
    BgNormal(Color(184, 184, 184)),
    BgMarcacao(Color(8, 179, 247)),
    BgExplosao(Color(189, 66, 68)),
    CorTxtVerde(Color(0, 100, 0))
}

class BotaoCampo(private val campo: Campo) : JButton() {

    init {
        font = font.deriveFont(Font.BOLD)
        background = CoresCampo.BgNormal.valor
        isOpaque = true
        border = BorderFactory.createBevelBorder(0)
        addMouseListener(MouseCliqueListener(campo, { it.abrir() }, { it.alterarMarcacao() }))

        campo.onEvento { _, campoEvento ->
            when (campoEvento) {
                CampoEvento.EXPLOSAO -> aplicarEstiloExplosao()
                CampoEvento.ABERTURA -> aplicarEstiloAbertura()
                CampoEvento.MARCACAO -> aplicarEstiloMarcacao()
                else -> aplicarEstiloDefault()
            }
            SwingUtilities.invokeLater {
                repaint()
                validate()
            }
        }
    }

    private fun aplicarEstiloExplosao() {
        background = CoresCampo.BgExplosao.valor
        text = "X"
    }

    private fun aplicarEstiloAbertura() {
        background = CoresCampo.BgNormal.valor
        border = BorderFactory.createLineBorder(Color.GRAY)

        foreground = when (campo.qtdVizinhosMinados) {
            1 -> CoresCampo.CorTxtVerde.valor
            2 -> Color.BLUE
            3 -> Color.YELLOW
            in 4..6 -> Color.RED
            else -> Color.PINK
        }

        text = if (campo.qtdVizinhosMinados > 0) campo.qtdVizinhosMinados.toString() else ""
    }

    private fun aplicarEstiloMarcacao() {
        background = CoresCampo.BgMarcacao.valor
        foreground = Color.BLACK
        text = "M"
    }

    private fun aplicarEstiloDefault() {
        background = CoresCampo.BgNormal.valor
        border = BorderFactory.createBevelBorder(0)
        text = ""
    }
}