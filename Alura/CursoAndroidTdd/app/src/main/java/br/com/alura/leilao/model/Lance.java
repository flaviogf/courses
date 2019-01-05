package br.com.alura.leilao.model;

import android.support.annotation.NonNull;

import java.io.Serializable;
import java.math.BigDecimal;

public class Lance implements Serializable, Comparable<Lance> {

    private final Usuario usuario;
    private final BigDecimal valor;

    public Lance(Usuario usuario, BigDecimal valor) {
        this.usuario = usuario;
        this.valor = valor;
    }

    public Usuario getUsuario() {
        return usuario;
    }

    public BigDecimal getValor() {
        return valor;
    }

    @Override
    public int compareTo(@NonNull Lance lance) {
        return lance.getValor().compareTo(valor);
    }
}
