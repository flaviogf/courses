package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Account account = new Account();

        account.deposit(1000);

        boolean result = account.withdraw(500);

        System.out.println(account.amount);

        System.out.println(result);
    }
}
