package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        try (Connection connection = new Connection()) {
            connection.execute();
        }
    }
}
