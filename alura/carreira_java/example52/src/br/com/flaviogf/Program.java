package br.com.flaviogf;

import java.nio.charset.StandardCharsets;

public class Program {

    public static void main(String[] args) {
        String sentence = "13º Órgão Oficial";

        byte[] bytesUTF8 = sentence.getBytes(StandardCharsets.UTF_8);
        System.out.println(StandardCharsets.UTF_8.displayName());
        System.out.println(bytesUTF8.length);
        System.out.println(new String(bytesUTF8, StandardCharsets.UTF_8));

        byte[] bytesUTF16 = sentence.getBytes(StandardCharsets.UTF_16);
        System.out.println(StandardCharsets.UTF_16.displayName());
        System.out.println(bytesUTF16.length);
        System.out.println(new String(bytesUTF16, StandardCharsets.UTF_16));

        byte[] bytesASC = sentence.getBytes(StandardCharsets.US_ASCII);
        System.out.println(StandardCharsets.US_ASCII.displayName());
        System.out.println(bytesASC.length);
        System.out.println(new String(bytesASC, StandardCharsets.US_ASCII));
    }
}
