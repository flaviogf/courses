package br.com.flaviogf;

import java.io.*;

public class Program {

    public static void main(String[] args) throws IOException, ClassNotFoundException {
        try (ObjectOutputStream outputStream = new ObjectOutputStream(new FileOutputStream("object.bin"))) {
            Customer customer = new Customer("Frank", "123");
            outputStream.writeObject(customer);
        }

        try (ObjectInputStream inputStream = new ObjectInputStream(new FileInputStream("object.bin"))) {
            Customer customer = (Customer) inputStream.readObject();
            System.out.println(customer.getName());
            System.out.println(customer.getDocument());
        }
    }
}
