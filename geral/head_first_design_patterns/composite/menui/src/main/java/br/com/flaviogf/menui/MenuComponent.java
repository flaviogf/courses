package br.com.flaviogf.menui;

import java.math.BigDecimal;
import java.util.Iterator;

public abstract class MenuComponent {
    public void add(MenuComponent component) {
        throw new UnsupportedOperationException();
    }

    public void remove(MenuComponent component) {
        throw new UnsupportedOperationException();
    }

    public MenuComponent getChild(int i) {
        throw new UnsupportedOperationException();
    }

    public String getName() {
        throw new UnsupportedOperationException();
    }

    public String getDescription() {
        throw new UnsupportedOperationException();
    }

    public BigDecimal getPrice() {
        throw new UnsupportedOperationException();
    }

    public Boolean isVegetarian() {
        throw new UnsupportedOperationException();
    }

    public void print() {
        throw new UnsupportedOperationException();
    }

    public abstract Iterator<MenuComponent> iterator();
}
