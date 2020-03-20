package br.com.flaviogf;

import java.io.File;
import java.io.IOException;
import java.util.Locale;
import java.util.Scanner;

public class Program {

    public static void main(String[] args) throws IOException {
        try (Scanner fileScanner = new Scanner(new File("accounts.csv"))) {
            while (fileScanner.hasNext()) {
                Scanner lineScanner = new Scanner(fileScanner.nextLine());

                lineScanner.useLocale(Locale.US);
                lineScanner.useDelimiter(",");

                String type = lineScanner.next();
                int number = lineScanner.nextInt();
                int agency = lineScanner.nextInt();
                String holder = lineScanner.next();
                double balance = lineScanner.nextDouble();
            }
        }
    }
}
