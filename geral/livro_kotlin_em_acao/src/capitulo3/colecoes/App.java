package capitulo3.colecoes;

import java.util.Arrays;

import static capitulo3.colecoes.StringUtils.*;

public class App {

    public static void main(String[] args) {
        String texto = joinToString(Arrays.asList("Teste", "Teste"));
        System.out.println(texto);
        char ultimoCaracter = lastChar("Flávio");
        System.out.println(ultimoCaracter);
        String colecaoJoinToString = colecaoJoinToString(Arrays.asList("", ""));
        System.out.println(colecaoJoinToString);
        System.out.println(getLastChar("Flávio"));
        View view = new Button();
        view.click();
        show(view);
    }
}
