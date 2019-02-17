package org.casadocodigo.models;

import javax.persistence.Embeddable;
import java.math.BigDecimal;

@Embeddable
public class Preco {

    private BigDecimal valor;
    private TipoPreco tipoPreco;

    public BigDecimal getValor() {
        return valor;
    }

    public void setValor(BigDecimal valor) {
        this.valor = valor;
    }

    public TipoPreco getTipoPreco() {
        return tipoPreco;
    }

    public void setTipoPreco(TipoPreco tipoPreco) {
        this.tipoPreco = tipoPreco;
    }
}
