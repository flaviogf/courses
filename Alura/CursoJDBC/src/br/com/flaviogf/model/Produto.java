package br.com.flaviogf.model;

import static java.lang.String.format;

public class Produto {

    private int id;
    private String nome;
    private String descricao;

    public Produto(int id, String nome, String descricao) {
        this.id = id;
        this.nome = nome;
        this.descricao = descricao;
    }

    @Override
    public String toString() {
        return format("Produto [id=%d, nome=%s descricao=%s]", id, nome, descricao);
    }
}
