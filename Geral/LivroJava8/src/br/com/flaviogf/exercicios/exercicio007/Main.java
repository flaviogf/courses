package br.com.flaviogf.exercicios.exercicio007;

public class Main {

    public static void main(String[] args) {
        int
        age
        = 100;
        System.out.println(age);

        boolean[] booleans = new boolean[300];
        System.out.println(booleans[0]);

        int a = 011; // octal = 9
        System.out.println(a);

        for (char i = 'a'; i <= 'z'; i++) {
            System.out.println(i);
        }

        String teste;
        if(args.length > 0) {
            teste = args[0];
        } else {
            System.out.println("???");
            return;
        }

        System.out.println(teste);
    }
}
