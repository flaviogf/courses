package br.com.flaviogf.laboratoriotestes.modelo;

import java.math.BigDecimal;
import java.time.LocalDateTime;

public class CandleStick {

  private final BigDecimal abertura;
  private final BigDecimal fechamento;
  private final BigDecimal volume;
  private final BigDecimal maximo;
  private final BigDecimal minimo;
  private final LocalDateTime data;

  public CandleStick(BigDecimal abertura, BigDecimal fechamento, BigDecimal volume,
      BigDecimal maximo, BigDecimal minimo, LocalDateTime data) {
    this.abertura = abertura;
    this.fechamento = fechamento;
    this.volume = volume;
    this.maximo = maximo;
    this.minimo = minimo;
    this.data = data;
  }

  public BigDecimal getAbertura() {
    return abertura;
  }

  public BigDecimal getFechamento() {
    return fechamento;
  }

  public BigDecimal getVolume() {
    return volume;
  }

  public BigDecimal getMaximo() {
    return maximo;
  }

  public BigDecimal getMinimo() {
    return minimo;
  }

  public LocalDateTime getData() {
    return data;
  }

  public boolean isAlta() {
    return fechamento.compareTo(abertura) > 0;
  }

  public boolean isBaixa() {
    return fechamento.compareTo(abertura) < 0;
  }
}
