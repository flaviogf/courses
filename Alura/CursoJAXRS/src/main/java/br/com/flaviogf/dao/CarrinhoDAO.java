package br.com.flaviogf.dao;

import br.com.flaviogf.modelo.Carrinho;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

public class CarrinhoDAO {

    private static List<Carrinho> carrinhos = new ArrayList<>(
            Arrays.asList(
                    new Carrinho(1L, Arrays.asList("PS4", "XBOX-ONE")),
                    new Carrinho(2L, Arrays.asList("PS3", "XBOX-360"))
            ));

    public List<Carrinho> lista() {
        return Collections.unmodifiableList(carrinhos);
    }

    public Carrinho buscaPor(Long id) {
        return carrinhos.stream()
                .filter(c -> c.getId().equals(id))
                .findFirst()
                .orElse(null);
    }

    public void insere(Carrinho carrinho) {
        carrinhos.add(carrinho);
    }
}
