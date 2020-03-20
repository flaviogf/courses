package br.com.flaviogf;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;

public class Program {

    public static void main(String[] args) throws IOException {
        try (FileInputStream fileInputStream = new FileInputStream("text.txt");
             InputStreamReader inputStreamReader = new InputStreamReader(fileInputStream);
             BufferedReader bufferedReader = new BufferedReader(inputStreamReader)) {

            String line = bufferedReader.readLine();

            System.out.println(line);
        }
    }
}
