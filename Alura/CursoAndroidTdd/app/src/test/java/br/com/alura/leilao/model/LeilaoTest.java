package br.com.alura.leilao.model;

import org.junit.Rule;
import org.junit.Test;
import org.junit.rules.ExpectedException;

import java.math.BigDecimal;
import java.util.List;

import br.com.alura.leilao.exceptions.MaisDeCincoLancesException;
import br.com.alura.leilao.exceptions.UltimoLanceMaiorException;
import br.com.alura.leilao.exceptions.UltimoUsuarioIgualException;

import static org.hamcrest.collection.IsCollectionWithSize.hasSize;
import static org.hamcrest.core.Is.is;
import static org.hamcrest.core.IsEqual.equalTo;
import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertThat;

public class LeilaoTest {

    private final Leilao CONSOLE = new Leilao("Console");
    private final Usuario FLAVIO = new Usuario("Flavio");
    private final Usuario FERNANDO = new Usuario("Fernando");

    @Rule
    public final ExpectedException EXCEPTION = ExpectedException.none();

    @Test
    public void deve_devolverDescricao_quandoRecebeDescricao() {
        String descricaoDevolvida = CONSOLE.getDescricao();
        assertThat(descricaoDevolvida, is(equalTo("Console")));
    }

    @Test
    public void deve_devolverMaiorLance_quandoRecebeApenasUmLance() {
        BigDecimal maiorLanceEsperado = new BigDecimal(200.0);
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(200.0)));
        BigDecimal maiorLanceDevolvido = CONSOLE.getMaiorLance();
        assertEquals(maiorLanceEsperado, maiorLanceDevolvido);
    }

    @Test
    public void deve_devolverMaiorLance_quandoRecebeMaisDeUmValorEmOrdemCrescente() {
        BigDecimal maiorLanceEsperado = new BigDecimal(200.0);
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(100.0)));
        CONSOLE.propoe(new Lance(FERNANDO, new BigDecimal(200.0)));
        BigDecimal maiorLanceDevolvido = CONSOLE.getMaiorLance();
        assertEquals(maiorLanceEsperado, maiorLanceDevolvido);
    }

    @Test
    public void deve_devolverMenorLance_quandoRecebeApenasUmLance() {
        BigDecimal menorLanceEsperado = new BigDecimal(200.0);
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(200.0)));
        BigDecimal menorLanceDevolvido = CONSOLE.getMenorLance();
        assertEquals(menorLanceEsperado, menorLanceDevolvido);
    }

    @Test
    public void deve_devolverMenorLance_quandoRecebeMaisDeUmLanceEmOrdemCrescente() {
        BigDecimal menorLanceEsperado = new BigDecimal(100.0);
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(100.0)));
        CONSOLE.propoe(new Lance(FERNANDO, new BigDecimal(200.0)));
        BigDecimal menorLanceDevolvido = CONSOLE.getMenorLance();
        assertEquals(menorLanceEsperado, menorLanceDevolvido);
    }

    @Test
    public void deve_devolverOsTresMaioresLances_quandoRecebeTresLances() {
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(200)));
        CONSOLE.propoe(new Lance(FERNANDO, new BigDecimal(250)));
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(300)));
        List<Lance> tresMaioresLances = CONSOLE.getTresMaioresLances();
        assertEquals(new BigDecimal(300), tresMaioresLances.get(0).getValor());
        assertEquals(new BigDecimal(250), tresMaioresLances.get(1).getValor());
        assertEquals(new BigDecimal(200), tresMaioresLances.get(2).getValor());
        assertEquals(3, tresMaioresLances.size());
        assertThat(tresMaioresLances, hasSize(3));
    }

    @Test
    public void deve_devolverZeroParaOMenorLance_quandoNaoTiverNenhumLance() {
        BigDecimal menorLanceDevolvido = CONSOLE.getMenorLance();
        assertEquals(new BigDecimal(0), menorLanceDevolvido);
    }

    @Test
    public void deve_devolerZeroParaOMaiorLance_quandoNaoTiverNenhumLance() {
        BigDecimal maiorLanceDevolvido = CONSOLE.getMaiorLance();
        assertEquals(new BigDecimal(0), maiorLanceDevolvido);
    }

    @Test
    public void naoDeve_aceitarLance_quandoProporUmLanceMenorQueOMaiorLance() {
        EXCEPTION.expect(UltimoLanceMaiorException.class);
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(200)));
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(100)));
    }

    @Test(expected = UltimoUsuarioIgualException.class)
    public void naoDeve_aceitarLances_quandoReceberDoisLancesSeguidosDoMesmoUsuario() {
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(200)));
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(200)));
        CONSOLE.propoe(new Lance(new Usuario("Flavio"), new BigDecimal(200)));
    }

    @Test(expected = MaisDeCincoLancesException.class)
    public void naoDeve_aceitarLances_quandoUsuarioJaTiverMaisDeCincoLances() {
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(200)));
        CONSOLE.propoe(new Lance(FERNANDO, new BigDecimal(300)));
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(400)));
        CONSOLE.propoe(new Lance(FERNANDO, new BigDecimal(500)));
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(600)));
        CONSOLE.propoe(new Lance(FERNANDO, new BigDecimal(700)));
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(800)));
        CONSOLE.propoe(new Lance(FERNANDO, new BigDecimal(900)));
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(1000)));
        CONSOLE.propoe(new Lance(FERNANDO, new BigDecimal(1100)));
        CONSOLE.propoe(new Lance(FLAVIO, new BigDecimal(1200)));
    }
}
