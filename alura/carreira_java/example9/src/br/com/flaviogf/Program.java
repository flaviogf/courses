package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
	    int age = 22;
	    int people = 2;
	    boolean accompanied = people > 1;

	    if(age > 22 || accompanied) {
            System.out.println("Welcome, you can enter!");
        } else {
            System.out.println("Sorry, you can't enter!");
        }
    }
}
