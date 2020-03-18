package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Account account = new Account();
        account.deposit(100);
        account.deposit(100);
        System.out.println(account.amount);
    }
}
