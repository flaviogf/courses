package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Account account1 = new Account("123", "1", 100);
        Account account2 = new CheckingAccount("456", "1", 100);
        Account account3 = new SavingsAccount("789", "1", 100);

        account1.transfer(100, account3);
        account2.transfer(100, account3);

        System.out.println(account1.getAmount());
        System.out.println(account2.getAmount());
        System.out.println(account3.getAmount());
    }
}
