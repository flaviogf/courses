package br.com.flaviogf.controllers;

import br.com.flaviogf.models.Produto;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.Collections;

public class Carrinho {

    private static Collection<Produto> produtos = new ArrayList<>();

    public void adiciona(Produto... produtos) {
        Carrinho.produtos.addAll(Arrays.asList(produtos));
    }

    public Collection<Produto> getProdutos() {
        return Collections.unmodifiableCollection(produtos);
    }
}
