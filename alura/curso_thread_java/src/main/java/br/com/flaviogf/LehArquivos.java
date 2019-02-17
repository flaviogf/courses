package br.com.flaviogf;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Arrays;
import java.util.Scanner;
import static java.lang.System.out;

public class LehArquivos {

    public static void main(String[] args) {

        String arquivo1 = "arquivos/assinaturas1.txt";
        String arquivo2 = "arquivos/assinaturas2.txt";
        String arquivo3 = "arquivos/autores.txt";
        String busca = "da";

        Arrays.asList(new Thread(() -> {
            try (Scanner scanner = new Scanner(new File(arquivo1))) {
                lehLinha(busca, scanner);
            } catch (FileNotFoundException ex) {

            }
        }), new Thread(() -> {
            try (Scanner scanner = new Scanner(new File(arquivo2))) {
                lehLinha(busca, scanner);
            } catch (FileNotFoundException ex) {

            }
        }), new Thread(() -> {
            try (Scanner scanner = new Scanner(new File(arquivo3))) {
                lehLinha(busca, scanner);
            } catch (FileNotFoundException ex) {

            }
        })).forEach(Thread::start);
    }

    private static void lehLinha(String busca, Scanner scanner) {
        while (scanner.hasNext()) {
            String linha = scanner.nextLine();
            if (linha.toLowerCase().contains(busca.toLowerCase())) {
                out.println(linha + " - " + Thread.currentThread().getName());
            }
        }
    }
}
