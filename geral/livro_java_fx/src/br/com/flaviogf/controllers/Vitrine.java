package br.com.flaviogf.controllers;

import br.com.flaviogf.models.Produto;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.Collections;
import java.util.stream.Collectors;

public class Vitrine {

    private static Collection<Produto> produtos = new ArrayList<>();

    public void adiciona(Produto... produtos) {
        Vitrine.produtos.addAll(Arrays.asList(produtos));
    }

    public Collection<Produto> getProdutos() {
        return Collections.unmodifiableCollection(produtos);
    }

    public Collection<Produto> filtra(String nome) {
        return produtos
                .stream()
                .filter(produto -> produto.getProduto().toUpperCase().contains(nome.toUpperCase()))
                .collect(Collectors.toUnmodifiableList());
    }
}
