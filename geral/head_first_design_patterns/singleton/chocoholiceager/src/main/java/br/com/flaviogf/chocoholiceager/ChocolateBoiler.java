package br.com.flaviogf.chocoholiceager;

public class ChocolateBoiler {
    public static ChocolateBoiler instance = new ChocolateBoiler();

    private boolean empty;

    private ChocolateBoiler() {
        empty = true;
    }

    public void fill() {
        empty = false;
    }

    public boolean isEmpty() {
        return empty;
    }

    @Override
    public String toString() {
        return "ChocolateBoiler{" +
                "empty=" + empty +
                '}' + super.toString();
    }

    public static ChocolateBoiler getInstance() {
        try {
            Thread.sleep(500);
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }

        return instance;
    }
}
