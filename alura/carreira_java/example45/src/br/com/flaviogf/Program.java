package br.com.flaviogf;

import java.text.DecimalFormat;

public class Program {

    public static void main(String[] args) {
        double median = 7.987654321;

        System.out.println(Math.round(median * 100.0) / 100.0);

        DecimalFormat format = new DecimalFormat("0.00");

        System.out.println(format.format(median));
    }
}
