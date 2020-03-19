package br.com.flaviogf;

import java.util.Arrays;

public class Items<T> {
    private Object[] elements = new Object[5];
    private int current = -1;
    private int size = 5;

    public void add(T element) {
        current++;

        if (current >= size) {
            size++;
            elements = Arrays.copyOf(elements, size);
        }

        elements[current] = element;
    }

    public T get(int i) {
        return (T) elements[i];
    }

    public int size() {
        return size;
    }
}
