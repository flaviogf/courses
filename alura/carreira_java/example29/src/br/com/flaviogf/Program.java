package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        try {
            checked();
        } catch (Exception ex) {
            ex.printStackTrace();
        }

        try {
            unchecked();
        } catch (RuntimeException ex) {
            ex.printStackTrace();
        }
    }

    public static void checked() throws Exception {
        throw new Exception();
    }

    public static void unchecked() {
        throw new RuntimeException();
    }
}
