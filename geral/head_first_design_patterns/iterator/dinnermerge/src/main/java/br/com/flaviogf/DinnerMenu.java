package br.com.flaviogf;

import java.math.BigDecimal;

public class DinnerMenu implements Menu {
    private static final int MAX_LENGTH = 6;

    private final MenuItem[] menuItems = new MenuItem[MAX_LENGTH];

    private int numberOfItems = 0;

    public DinnerMenu() {
        addItem("Vegetarian BLT", "(Fakin´) Bacon with lettuce & tomato on whole wheat", true, new BigDecimal("2.99"));
    }

    private void addItem(String name, String description, Boolean isVegetarian, BigDecimal price) {
        if (numberOfItems >= MAX_LENGTH) {
            throw new UnsupportedOperationException();
        }

        MenuItem menuItem = new MenuItem(name, description, isVegetarian, price);

        menuItems[numberOfItems] = menuItem;

        numberOfItems++;
    }

    public Iterator<MenuItem> iterator() {
        return new DinnerMenuIterator(menuItems);
    }
}
