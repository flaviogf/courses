package br.com.flaviogf.menui;

import java.util.Iterator;

public class Waitress {
    private final MenuComponent allMenus;

    public Waitress(MenuComponent allMenus) {
        this.allMenus = allMenus;
    }

    public void printMenu() {
        allMenus.print();
    }

    public void printVegetarianMenu() {
        Iterator<MenuComponent> iterator = allMenus.iterator();

        while (iterator.hasNext()) {
            try {
                MenuComponent component = iterator.next();

                if (!component.isVegetarian()) {
                    continue;
                }

                component.print();
            } catch (UnsupportedOperationException ignored) {
            }
        }
    }
}
