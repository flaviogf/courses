package br.com.flaviogf.dinnermergei;

import java.math.BigDecimal;

public class MenuItem {
    private final String name;
    private final String description;
    private final Boolean vegetarian;
    private final BigDecimal price;

    public MenuItem(String name, String description, Boolean vegetarian, BigDecimal price) {
        this.name = name;
        this.description = description;
        this.vegetarian = vegetarian;
        this.price = price;
    }

    public String getName() {
        return name;
    }

    public String getDescription() {
        return description;
    }

    public Boolean isVegetarian() {
        return vegetarian;
    }

    public BigDecimal getPrice() {
        return price;
    }

    @Override
    public String toString() {
        return String.format("%s, %.2f -- %s", name, price, description);
    }
}
