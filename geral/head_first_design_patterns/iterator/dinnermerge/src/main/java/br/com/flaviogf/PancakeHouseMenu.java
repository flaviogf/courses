package br.com.flaviogf;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

public class PancakeHouseMenu implements Menu {
    private final List<MenuItem> menuItems = new ArrayList<>();

    public PancakeHouseMenu() {
        addItem("'K&B's Pancake Breakfast", "Pancake with scrambled eggs", true, new BigDecimal("2.99"));
        addItem("Regular Pancake Breakfast", "Pancakes with fried eggs, sausage", false, new BigDecimal("2.99"));
    }

    private void addItem(String name, String description, Boolean isVegetarian, BigDecimal price) {
        MenuItem menuItem = new MenuItem(name, description, isVegetarian, price);
        menuItems.add(menuItem);
    }

    public Iterator<MenuItem> iterator() {
        return new PancakeHouseMenuIterator(menuItems);
    }
}
