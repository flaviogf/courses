package br.com.flaviogf.chocoholic;

public class ChocolateBoiler {
    private static ChocolateBoiler instance;
    private boolean empty;
    private boolean boiled;

    private ChocolateBoiler() {
        empty = true;
        boiled = false;
    }

    public void fill() {
        if (isEmpty()) {
            empty = false;
            boiled = false;
        }

    }

    public void drain() {
        if (!isEmpty() && isBoiled()) {
            empty = true;
        }
    }

    public void boil() {
        if (!isEmpty() && !isBoiled()) {
            boiled = true;
        }
    }

    public boolean isEmpty() {
        return empty;
    }

    public boolean isBoiled() {
        return boiled;
    }

    @Override
    public String toString() {
        return "ChocolateBoiler{" +
                "empty=" + empty +
                ", boiled=" + boiled +
                '}';
    }

    public static ChocolateBoiler getInstance() {
        if (instance == null) {
            instance = new ChocolateBoiler();
        }

        return instance;
    }
}
