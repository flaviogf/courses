package br.com.flaviogf;

public class DinnerMenuIterator implements Iterator<MenuItem> {
    private final MenuItem[] menuItems;
    private int position = 0;

    public DinnerMenuIterator(MenuItem[] menuItems) {
        this.menuItems = menuItems;
    }

    public Boolean hasNext() {
        return position < menuItems.length && menuItems[position] != null;
    }

    public MenuItem next() {
        MenuItem menuItem = menuItems[position];
        position++;
        return menuItem;
    }
}
