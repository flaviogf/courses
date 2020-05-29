package br.com.flaviogf.chocoholicdoublechecked;

public class ChocolateBoiler {
    private static ChocolateBoiler instance;
    private boolean empty;

    private ChocolateBoiler() {
        empty = true;
    }

    public void fill() {
        if (isEmpty()) {
            empty = false;
        }
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

        if (instance == null) {
            synchronized (ChocolateBoiler.class) {
                if (instance == null) {
                    instance = new ChocolateBoiler();
                }
            }
        }
        return instance;
    }
}
