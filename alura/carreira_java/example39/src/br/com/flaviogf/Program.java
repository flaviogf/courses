package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Items<String> items = new Items<>();

        for (int i = 0; i < 10; i++) {
            items.add(Integer.toString(i));
        }

        for (int i = 0; i < items.length(); i++) {
            String item = items.get(i);
            System.out.println(item);
        }
    }
}
