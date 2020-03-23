package br.com.flaviogf.example55;

import java.text.DateFormat;
import java.text.MessageFormat;
import java.text.NumberFormat;
import java.util.Date;
import java.util.Locale;
import java.util.ResourceBundle;

public class App {
    public static void main(String[] args) {
        Locale ptBR = new Locale("pt","BR");

        DateFormat dateFormat = DateFormat.getDateInstance(DateFormat.FULL,ptBR);
        System.out.println(dateFormat.format(new Date()));

        NumberFormat currencyFormat = NumberFormat.getCurrencyInstance(ptBR);
        System.out.println(currencyFormat.format(25.55));

        NumberFormat numberFormat = NumberFormat.getNumberInstance(ptBR);
        System.out.println(numberFormat.format(25.55));

        System.out.println(ResourceBundle.getBundle("messages", ptBR).getString("required"));
        System.out.println(ResourceBundle.getBundle("messages").getString("required"));

        System.out.println(MessageFormat.format("Hoje é {0}", dateFormat.format(new Date())));
    }
}
