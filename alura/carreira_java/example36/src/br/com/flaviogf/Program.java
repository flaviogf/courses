package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        String document = "123.123.123-88";
        String zipCode = "14404-045";
        System.out.println(clean(document));
        System.out.println(clean(zipCode));
    }

    public static String clean(String value) {
        return value.replaceAll("[\\D]", "");
    }
}
