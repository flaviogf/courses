package br.com.flaviogf.model;

import java.util.ArrayList;
import java.util.List;

import static java.lang.String.format;

public class Categoria {

    private int id;
    private String nome;
    private List<Produto> produtos;

    public Categoria(int id, String nome) {
        this.id = id;
        this.nome = nome;
        this.produtos = new ArrayList<>();
    }

    public String getNome() {
        return this.nome;
    }

    public void adiciona(Produto produto) {
        produtos.add(produto);
    }

    @Override
    public String toString() {
        return format("Categoria[id=%d, nome=%s, produtos=%s]", id, nome, produtos);
    }
}
