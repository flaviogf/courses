package br.com.flaviogf.chocoholicsynchronized;

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
        if (!isEmpty() && isBoiled()) {
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
                '}' + super.toString();
    }

    public static synchronized ChocolateBoiler getInstance() {
        try {
            Thread.sleep(500);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }

        if (instance == null) {
            instance = new ChocolateBoiler();
        }

        return instance;
    }
}
