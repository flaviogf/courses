package br.com.flaviogf.laboratoriotestes.modelo;

import static br.com.flaviogf.laboratoriotestes.utils.ArrayUtils.primeiro;
import static br.com.flaviogf.laboratoriotestes.utils.ArrayUtils.ultimo;
import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.Comparator;
import java.util.stream.Stream;

public class CandleStickFactory {

  public static CandleStick cria(Negociacao... negociacoes) {
    BigDecimal abertura = primeiro(negociacoes).map(Negociacao::getValor).orElse(BigDecimal.ZERO);
    BigDecimal fechamento = ultimo(negociacoes).map(Negociacao::getValor).orElse(BigDecimal.ZERO);
    BigDecimal volume = Stream.of(negociacoes).map(Negociacao::getVolume)
        .reduce((it, acumulador) -> it.add(acumulador)).orElse(BigDecimal.ZERO);
    BigDecimal maximo = Stream.of(negociacoes).max(Comparator.naturalOrder())
        .map(Negociacao::getValor).orElse(BigDecimal.ZERO);
    BigDecimal minimo = Stream.of(negociacoes).min(Comparator.naturalOrder())
        .map(Negociacao::getValor).orElse(BigDecimal.ZERO);
    LocalDateTime data = LocalDateTime.now();
    return new CandleStick(abertura, fechamento, volume, maximo, minimo, data);
  }
}
