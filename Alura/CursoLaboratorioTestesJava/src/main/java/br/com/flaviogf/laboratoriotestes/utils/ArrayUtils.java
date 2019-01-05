package br.com.flaviogf.laboratoriotestes.utils;

import java.util.Optional;

public class ArrayUtils {

  public static <T> Optional<T> primeiro(T[] itens) {
    return itens.length > 0 ? Optional.of(itens[0]) : Optional.empty();
  }

  public static <T> Optional<T> ultimo(T[] itens) {
    return itens.length > 0 ? Optional.of(itens[itens.length - 1]) : Optional.empty();
  }
}
