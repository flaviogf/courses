package br.com.flaviogf;

public class Connection implements AutoCloseable {
    public Connection() {
        System.out.println("It's opening");

        throw new RuntimeException();
    }

    public void execute() {
        System.out.println("It's executing");
    }

    @Override
    public void close() {
        System.out.println("It's closing.");
    }
}
