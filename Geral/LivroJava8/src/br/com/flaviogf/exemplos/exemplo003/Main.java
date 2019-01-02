package br.com.flaviogf.exemplos.exemplo003;

import java.util.Arrays;
import java.util.Comparator;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        List<String> palavras1 = Arrays.asList("Item 3", "Item 1", "Item 2");
        List<String> palavras2 = Arrays.asList("Item 3", "Item 1", "Item 2");
        List<String> palavras3 = Arrays.asList("Item 3", "Item 1", "Item 2");
        List<String> palavras4 = Arrays.asList("Item 3", "Item 1", "Item 2");

        palavras1.sort(new Comparator<String>() {
            @Override
            public int compare(String o1, String o2) {
                return o1.compareTo(o2);
            }
        });

        palavras2.sort((o1, o2) -> o1.compareTo(o2));

        palavras3.sort(String::compareTo);

        palavras4.sort(Comparator.comparing(nome -> nome));

        System.out.println(palavras1);
        System.out.println(palavras2);
        System.out.println(palavras3);
        System.out.println(palavras4);
    }
}
