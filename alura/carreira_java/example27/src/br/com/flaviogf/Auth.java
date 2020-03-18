package br.com.flaviogf;

public class Auth {
    public void authenticate(CanAuthenticate canAuthenticate) {
        if (canAuthenticate.authenticate("right")) {
            System.out.println("It was authenticated.");
            return;
        }

        System.out.println("It wasn't authenticated.");
    }
}
