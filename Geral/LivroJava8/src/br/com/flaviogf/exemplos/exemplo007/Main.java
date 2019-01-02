package br.com.flaviogf.exemplos.exemplo007;

public class Main {

    public static void main(String[] args) {
        exemplo1();
        StringBuilder stringBuilder = new StringBuilder();
        String nome = stringBuilder.append("guilherme").delete(2, 3).toString();
        System.out.println(nome);
    }

    private static void exemplo1() {
        StringBuilder builder = new StringBuilder();
        builder.append("Flavio");
        builder.append(" - ");
        builder.append("Fernandes");
        builder.insert(7, "teste ");
        builder.delete(7, 13);
        System.out.println(builder);
    }
}
