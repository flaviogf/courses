package br.com.alura.leilao.utils;

import java.util.List;
import java.util.Optional;

public class CollectionUtils {

    public static <T> Optional<T> getUltimoItem(List<T> lista) {
        if (lista.isEmpty()) return Optional.empty();
        return Optional.of(lista.get(lista.size() - 1));
    }
}
