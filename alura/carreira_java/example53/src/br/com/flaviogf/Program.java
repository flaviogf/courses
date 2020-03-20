package br.com.flaviogf;

import java.io.*;

public class Program {

    public static void main(String[] args) throws IOException, ClassNotFoundException {

        try (ObjectOutputStream outputStream = new ObjectOutputStream(new FileOutputStream("object.bin"))) {
            String sentence = "Lorem ipsum dolor";
            outputStream.writeObject(sentence);
        }

        try (ObjectInputStream outputStream = new ObjectInputStream(new FileInputStream("object.bin"))) {
            String sentence = (String) outputStream.readObject();
            System.out.println(sentence);
        }
    }
}
