package br.com.flaviogf.schedule.infrastructure;

public class Maybe<T> {
    private final T value;

    private Maybe(T value) {
        this.value = value;
    }

    public Boolean hasValue() {
        return value != null;
    }

    public T getValue() {
        if (value == null) {
            throw new UnsupportedOperationException();
        }

        return value;
    }

    public static <T> Maybe<T> of(T value) {
        return new Maybe<>(value);
    }

    public static <T> Maybe<T> empty() {
        return new Maybe<>(null);
    }
}
