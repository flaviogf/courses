package br.com.flaviogf;

import java.util.List;

public class PancakeHouseMenuIterator implements Iterator<MenuItem> {
    private final List<MenuItem> menuItems;

    private int position = 0;

    public PancakeHouseMenuIterator(List<MenuItem> menuItems) {
        this.menuItems = menuItems;
    }

    @Override
    public Boolean hasNext() {
        return position < menuItems.size() && menuItems.get(position) != null;
    }

    @Override
    public MenuItem next() {
        MenuItem menuItem = menuItems.get(position);
        position++;
        return menuItem;
    }
}
