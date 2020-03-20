package br.com.flaviogf;

import java.io.File;
import java.io.IOException;
import java.util.Locale;
import java.util.Scanner;

public class Program {

    public static void main(String[] args) throws IOException {
        try (Scanner fileScanner = new Scanner(new File("accounts.csv"))) {
            while (fileScanner.hasNext()) {
                try (Scanner lineScanner = new Scanner(fileScanner.nextLine())) {
                    lineScanner.useDelimiter(",");
                    lineScanner.useLocale(Locale.US);

                    String accountType = lineScanner.next();
                    int agency = lineScanner.nextInt();
                    int number = lineScanner.nextInt();
                    String name = lineScanner.next();
                    double balance = lineScanner.nextDouble();

                    System.out.println(String.format(new Locale("pt", "BR"), "%s %04d-04%d %s %.2f", accountType, agency, number, name, balance));
                }
            }
        }
    }
}
