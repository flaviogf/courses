package br.com.flaviogf.laboratoriotestes.modelo;

import static org.hamcrest.core.Is.is;
import static org.hamcrest.core.IsEqual.equalTo;
import static org.junit.Assert.assertThat;
import java.math.BigDecimal;
import java.time.LocalDateTime;
import org.junit.Test;

public class NegociacaoTest {

  @Test(expected = IllegalArgumentException.class)
  public void naoDeve_criarNegociacao_ComValorMenorIgualAZero() {
    new Negociacao(new BigDecimal(0), new Integer(100), LocalDateTime.now());
    new Negociacao(null, new Integer(100), LocalDateTime.now());
    new Negociacao(new BigDecimal(-1), new Integer(100), LocalDateTime.now());
  }

  @Test
  public void deve_retornarTodosDadosDeUmaNegociacao_quandoQuandoCriaUmaNegociacao() {
    BigDecimal valor = new BigDecimal(100);
    Integer quantidade = new Integer(100);
    LocalDateTime data = LocalDateTime.now();
    Negociacao negociacao = new Negociacao(valor, quantidade, data);
    assertThat(valor, is(equalTo(negociacao.getValor())));
    assertThat(quantidade, is(equalTo(negociacao.getQuantidade())));
    assertThat(data, is(equalTo(negociacao.getData())));
    assertThat(valor.multiply(new BigDecimal(quantidade)), is(equalTo(negociacao.getVolume())));
  }
}
