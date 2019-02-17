package br.com.flaviogf.laboratoriotestes.modelo;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertThat;
import static org.junit.Assert.assertTrue;
import java.math.BigDecimal;
import java.time.LocalDateTime;
import static org.hamcrest.core.Is.is;
import static org.hamcrest.core.IsEqual.equalTo;
import org.junit.Test;

public class CandleStickTest {

  @Test
  public void deve_retornarTodosOsDadosDeUmCandleStick_quandoCriaUmCandleStick() {
    BigDecimal abertura = new BigDecimal(100);
    BigDecimal fechamento = new BigDecimal(200);
    BigDecimal volume = new BigDecimal(500);
    BigDecimal maximo = new BigDecimal(250);
    BigDecimal minimo = new BigDecimal(100);
    LocalDateTime data = LocalDateTime.now();
    CandleStick candleStick = new CandleStick(abertura, fechamento, volume, maximo, minimo, data);
    assertThat(abertura, is(equalTo(candleStick.getAbertura())));
    assertThat(fechamento, is(equalTo(candleStick.getFechamento())));
    assertThat(volume, is(equalTo(candleStick.getVolume())));
    assertThat(maximo, is(equalTo(candleStick.getMaximo())));
    assertThat(minimo, is(equalTo(candleStick.getMinimo())));
    assertTrue(candleStick.isAlta());
    assertFalse(candleStick.isBaixa());
  }
}
