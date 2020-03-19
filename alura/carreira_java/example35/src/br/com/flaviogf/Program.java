package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        String title = "Java EE";
        String author = "Alberto Souza";
        String description = "A especificação Java EE e suas respectivas "
                + "implementações vêm evoluindo ao longo do tempo. "
                + "A configuração e utilização das especificações "
                + "ficaram bem mais fáceis. O que ainda não é "
                + "tão fácil de enxergar é como podemos colocá-las "
                + "para trabalhar em conjunto. Quais eu devo usar "
                + "no meu próximo projeto? O que realmente eu posso "
                + "fazer com cada uma delas? Como fazer com que uma "
                + "converse com a outra?";

        Book book = new Book(title, author, description);

        System.out.println(book);
    }
}
