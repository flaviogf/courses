package br.com.flaviogf.menui;

import java.util.ArrayDeque;
import java.util.Iterator;
import java.util.Queue;

public class CompositeIterator implements Iterator<MenuComponent> {
    private final Queue<Iterator<MenuComponent>> queue = new ArrayDeque<>();

    public CompositeIterator(Iterator<MenuComponent> iterator) {
        queue.add(iterator);
    }

    @Override
    public MenuComponent next() {
        if (!hasNext()) {
            return null;
        }

        Iterator<MenuComponent> iterator = queue.peek();

        MenuComponent component = iterator.next();

        queue.add(component.iterator());

        return component;
    }

    @Override
    public boolean hasNext() {
        if (queue.isEmpty()) {
            return false;
        }

        Iterator<MenuComponent> iterator = queue.peek();

        if (iterator.hasNext()) {
            return true;
        }

        queue.remove();

        return hasNext();
    }

    @Override
    public void remove() {
        throw new UnsupportedOperationException();
    }
}
