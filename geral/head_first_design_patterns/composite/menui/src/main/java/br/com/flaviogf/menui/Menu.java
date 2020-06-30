package br.com.flaviogf.menui;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class Menu extends MenuComponent {
    private final List<MenuComponent> components = new ArrayList<>();
    private final String name;
    private final String description;

    public Menu(String name, String description) {
        this.name = name;
        this.description = description;
    }

    @Override
    public void add(MenuComponent component) {
        components.add(component);
    }

    @Override
    public void remove(MenuComponent component) {
        components.remove(component);
    }

    @Override
    public MenuComponent getChild(int index) {
        return components.get(index);
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
    public void print() {
        System.out.println(String.format("Name: %s, Description: %s", name, description));

        for (MenuComponent component : components) {
            component.print();
        }
    }

    @Override
    public Iterator<MenuComponent> iterator() {
        return new CompositeIterator(components.iterator());
    }
}
