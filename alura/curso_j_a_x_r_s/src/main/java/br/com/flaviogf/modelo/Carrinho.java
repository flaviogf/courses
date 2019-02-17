package br.com.flaviogf.modelo;

import java.util.List;

import static java.lang.String.format;

public class Carrinho {

    private Long id;

    private List<String> produtos;

    public Carrinho(Long id, List<String> produtos) {
        this.id = id;
        this.produtos = produtos;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public List<String> getProdutos() {
        return produtos;
    }

    public void setProdutos(List<String> produtos) {
        this.produtos = produtos;
    }

    @Override
    public String toString() {
        return format("Carrinho[id=%s, produtos=%s]", id, produtos);
    }
}
