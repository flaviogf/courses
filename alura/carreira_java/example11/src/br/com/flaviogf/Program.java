package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        int counter = 0;
        int sum = 0;

        while (counter < 10) {
            sum += counter;
            System.out.println(sum);
            counter++;
        }
    }
}
