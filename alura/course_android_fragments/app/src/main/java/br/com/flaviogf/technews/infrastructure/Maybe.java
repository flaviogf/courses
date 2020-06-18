package br.com.flaviogf.technews.infrastructure;

public class Maybe<T> {
    private final T value;

    private Maybe(T value) {
        this.value = value;
    }

    public Boolean hasValue() {
        return value != null;
    }

    public T getValue() {
        return value;
    }

    public static <T> Maybe<T> of(T value) {
        return new Maybe<>(value);
    }

    public static <T> Maybe<T> empty() {
        return new Maybe<>(null);
    }
}
