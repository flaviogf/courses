package br.com.flaviogf.laboratoriotestes.modelo;

import java.math.BigDecimal;
import java.time.LocalDateTime;

public class Negociacao implements Comparable<Negociacao> {

  private final BigDecimal valor;
  private final Integer quantidade;
  private final LocalDateTime data;

  public Negociacao(BigDecimal valor, Integer quantidade, LocalDateTime data) {
    if (valor == null || valor.compareTo(new BigDecimal(0)) <= 0) {
      throw new IllegalArgumentException("O valor nao pode ser nulo ou menor que zero");
    }
    this.valor = valor;
    this.quantidade = quantidade;
    this.data = data;
  }

  public BigDecimal getValor() {
    return valor;
  }

  public Integer getQuantidade() {
    return quantidade;
  }

  public LocalDateTime getData() {
    return data;
  }

  public BigDecimal getVolume() {
    return valor.multiply(new BigDecimal(quantidade));
  }

  @Override
  public int compareTo(Negociacao negociacao) {
    return negociacao.getVolume().compareTo(getVolume());
  }
}
