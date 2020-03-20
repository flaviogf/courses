package br.com.flaviogf;

import java.io.*;

public class Program {

    public static void main(String[] args) throws IOException {
        FileOutputStream fileOutputStream = new FileOutputStream("text.txt");
        OutputStreamWriter outputStreamWriter = new OutputStreamWriter(fileOutputStream);
        BufferedWriter bufferedWriter = new BufferedWriter(outputStreamWriter);

        bufferedWriter.write("Frank");
        bufferedWriter.newLine();
        bufferedWriter.write("Nina");
        bufferedWriter.newLine();

        bufferedWriter.close();
    }
}
