package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Account first = new Account();

        first.amount = 200;

        System.out.println(first.amount);

        Account second = first;

        second.amount += 200;

        System.out.println(first.amount);
    }
}
