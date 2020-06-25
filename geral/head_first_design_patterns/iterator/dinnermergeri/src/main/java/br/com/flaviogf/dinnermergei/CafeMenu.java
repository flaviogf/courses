package br.com.flaviogf.dinnermergei;

import java.math.BigDecimal;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

public class CafeMenu implements Menu {
    private final Map<String, MenuItem> menuItems = new HashMap<>();

    public CafeMenu() {
        addItem("Veggie Burger and Air Fries",
                "Veggie burger on a whole wheat bun, lettuce, tomato, and fries",
                true,
                new BigDecimal("3.99"));

        addItem("Soup of the day",
                "A cup of the soup of the day, with a side salad",
                false,
                new BigDecimal("3.69"));

        addItem("Burrito",
                "A large burrito, with whole pinto beans, salsa, guacamole",
                true,
                new BigDecimal("4.29"));
    }

    private void addItem(String name, String description, boolean vegetarian, BigDecimal price) {
        menuItems.put(name, new MenuItem(name, description, vegetarian, price));
    }

    @Override
    public Iterator<MenuItem> iterator() {
        return menuItems.values().iterator();
    }
}
