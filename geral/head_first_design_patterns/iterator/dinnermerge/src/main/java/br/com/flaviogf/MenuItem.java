package br.com.flaviogf;

import java.math.BigDecimal;

public class MenuItem {
    private final String name;
    private final String description;
    private final Boolean isVegetarian;
    private final BigDecimal price;

    public MenuItem(String name, String description, Boolean isVegetarian, BigDecimal price) {
        this.name = name;
        this.description = description;
        this.isVegetarian = isVegetarian;
        this.price = price;
    }

    public String getName() {
        return name;
    }

    public String getDescription() {
        return description;
    }

    public Boolean getVegetarian() {
        return isVegetarian;
    }

    public BigDecimal getPrice() {
        return price;
    }

    @Override
    public String toString() {
        return String.format("%s, %.2f -- %s", name, price, description);
    }
}
