package br.com.flaviogf.casadocodigo.models;

import java.math.BigDecimal;

import javax.persistence.Embeddable;

@Embeddable
public class Price {
    private BigDecimal value;
    private EPriceType type;

    @Deprecated
    public Price() {
    }

    public void setValue(BigDecimal value) {
        this.value = value;
    }

    public BigDecimal getValue() {
        return value;
    }

    public void setType(EPriceType type) {
        this.type = type;
    }

    public EPriceType getType() {
        return type;
    }

    @Override
    public String toString() {
        return String.format("Price[value=%f, type=%s]", value, type);
    }
}
