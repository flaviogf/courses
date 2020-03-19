package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Account[] accounts = new Account[]{
                new CheckingAccount("123", "1"),
                new SavingsAccount("456", "1")
        };

        for (Account account : accounts) {
            System.out.println(account);
        }
    }
}
