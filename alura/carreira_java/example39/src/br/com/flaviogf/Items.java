package br.com.flaviogf;

import java.util.Arrays;

public class Items<T> {
    private Object[] elements = new Object[5];
    private int current = -1;
    private int length = 5;

    public void add(T element) {
        current++;

        if (current >= length) {
            length++;
            elements = Arrays.copyOf(elements, length);
        }

        elements[current] = element;
    }

    public T get(int i) {
        return (T) elements[i];
    }

    public int length() {
        return length;
    }
}
