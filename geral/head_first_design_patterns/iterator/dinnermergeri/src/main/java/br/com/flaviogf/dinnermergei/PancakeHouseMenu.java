package br.com.flaviogf.dinnermergei;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class PancakeHouseMenu implements Menu {
    private final List<MenuItem> menuItems = new ArrayList<>();

    public PancakeHouseMenu() {
        addItem("K&B's Pancake Breakfast",
                "Pancakes with scrambled eggs, and toast",
                true,
                new BigDecimal("2.99"));

        addItem("Regular Pancake Breakfast",
                "Pancakes with fried eggs, sausage",
                false,
                new BigDecimal("2.99"));

        addItem("Blueberry Pancakes",
                "Pancakes made with fresh blueberries, and blueberry syrup",
                true,
                new BigDecimal("3.49"));

        addItem("Waffles",
                "Waffles, with your choice of blueberries or strawberries",
                true,
                new BigDecimal("3.59"));
    }

    private void addItem(String name, String description, boolean vegetarian, BigDecimal price) {
        menuItems.add(new MenuItem(name, description, vegetarian, price));
    }

    @Override
    public Iterator<MenuItem> iterator() {
        return menuItems.iterator();
    }
}
