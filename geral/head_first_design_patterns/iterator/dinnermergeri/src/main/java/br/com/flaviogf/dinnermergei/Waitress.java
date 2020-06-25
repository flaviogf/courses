package br.com.flaviogf.dinnermergei;

import java.util.Iterator;
import java.util.List;

public class Waitress {
    private final List<Menu> menus;

    public Waitress(List<Menu> menus) {
        this.menus = menus;
    }

    public void printMenus() {
        Iterator<Menu> iterator = menus.iterator();
        while (iterator.hasNext()) {
            Menu menu = iterator.next();
            printMenu(menu);
        }
    }

    private void printMenu(Menu menu) {
        Iterator<MenuItem> iterator = menu.iterator();
        while (iterator.hasNext()) {
            MenuItem menuItem = iterator.next();
            System.out.println(menuItem);
        }
    }
}
