package br.com.flaviogf.menui;

import java.math.BigDecimal;
import java.util.Iterator;

public class MenuItem extends MenuComponent {
    private final String name;
    private final String description;
    private final BigDecimal price;
    private final Boolean isVegetarian;

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
    public BigDecimal getPrice() {
        return price;
    }

    @Override
    public Boolean isVegetarian() {
        return isVegetarian;
    }

    @Override
    public void print() {
        System.out.println(String.format(" Name: %s, Vegetarian: %b, Price: %.2f, Description: %s", name, isVegetarian, price, description));
    }

    @Override
    public Iterator<MenuComponent> iterator() {
        return new NullIterator();
    }
}
