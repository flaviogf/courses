package br.com.flaviogf.laboratoriotestes.modelo;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertThat;
import static org.junit.Assert.assertTrue;
import java.math.BigDecimal;
import java.time.LocalDateTime;
import org.junit.Test;
import static org.hamcrest.core.Is.is;
import static org.hamcrest.core.IsEqual.equalTo;

public class CandleStickFactoryTest {

  @Test
  public void deve_retornarUmCandleStick_quandoPassarUmaListaDeNegociacoes() {
    Negociacao negociacao1 =
        new Negociacao(new BigDecimal(100), new Integer(10), LocalDateTime.now());
    Negociacao negociacao2 =
        new Negociacao(new BigDecimal(50), new Integer(10), LocalDateTime.now());
    CandleStick candleStick = CandleStickFactory.cria(negociacao1, negociacao2);
    BigDecimal volumeEsperado = negociacao1.getVolume().add(negociacao2.getVolume());
    assertThat(volumeEsperado, is(equalTo(candleStick.getVolume())));
    assertFalse(candleStick.isAlta());
    assertTrue(candleStick.isBaixa());
  }

  @Test
  public void deve_retornarZeroParaTodosValores_quandoNaoPassarUmaListaDeNegociacoes() {
    CandleStick candleStick = CandleStickFactory.cria();
    assertEquals(BigDecimal.ZERO, candleStick.getAbertura());
    assertEquals(BigDecimal.ZERO, candleStick.getFechamento());
    assertEquals(BigDecimal.ZERO, candleStick.getMaximo());
    assertEquals(BigDecimal.ZERO, candleStick.getMinimo());
    assertEquals(BigDecimal.ZERO, candleStick.getVolume());
  }
}
