package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        String name = "Frank;Rex;Nina;Tank";
        String phone1 = "16999999999";
        String phone2 = "1699999999";

        System.out.println(name.charAt(0));
        System.out.println(name.contains("k"));
        System.out.println(name.isEmpty());
        System.out.println(name.replaceAll(";", ","));
        System.out.println(phoneMask(phone1));
        System.out.println(phoneMask(phone2));
    }

    public static String phoneMask(String phone) {
        return phone.replaceAll("\\D", "")
                .replaceFirst("(\\d{2})", "($1) ")
                .replaceFirst("(\\d{4})$", "-$1");
    }
}
