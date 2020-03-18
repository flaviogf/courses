package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Account account = new Account("1234", "5678");

        account.deposit(1000);
        account.withdraw(500);

        System.out.println(account.getNumber());
        System.out.println(account.getAgency());
        System.out.println(account.getAmount());
    }
}
