package br.com.flaviogf;

import java.io.IOException;
import java.io.PrintStream;
import java.io.PrintWriter;

public class Program {

    public static void main(String[] args) throws IOException {
        try (PrintStream stream = new PrintStream("dogs.txt")) {
            stream.println("Frank");
            stream.println("Tank");
        }

        try (PrintWriter writer = new PrintWriter("people.txt")) {
            writer.println("Luis");
            writer.println("Fatima");
        }
    }
}
