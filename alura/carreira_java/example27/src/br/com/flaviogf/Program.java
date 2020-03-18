package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Auth auth = new Auth();

        CanAuthenticate canAuthenticate1 = new Manager("Frank", "123", 1000);
        canAuthenticate1.setPassword("right");
        CanAuthenticate canAuthenticate2 = new Customer("Fernando");
        canAuthenticate2.setPassword("wrong");

        auth.authenticate(canAuthenticate1);
        auth.authenticate(canAuthenticate2);
    }
}
