package br.com.flaviogf.menu;

import java.math.BigDecimal;

public class MenuItem extends MenuComponent {
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

    @Override
    public String getName() {
        return name;
    }

    @Override
    public String getDescription() {
        return description;
    }

    @Override
    public Boolean isVegetarian() {
        return isVegetarian;
    }

    @Override
    public BigDecimal getPrice() {
        return price;
    }

    @Override
    public void print() {
        System.out.print(" " + getName());

        if (isVegetarian()) {
            System.out.print("(v)");
        }

        System.out.println(", " + getPrice());
        System.out.println(" -- " + getDescription());
    }
}
