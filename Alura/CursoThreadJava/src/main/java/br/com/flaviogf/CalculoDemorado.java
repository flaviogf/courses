package br.com.flaviogf;

import java.math.BigInteger;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class CalculoDemorado {

    public static void main(String[] args) {

        JFrame janela = new JFrame("Multiplicação Demorada");

        JTextField primeiro = new JTextField(10);
        JTextField segundo = new JTextField(10);
        JLabel x = new JLabel("x");
        JButton botao = new JButton(" = ");
        JLabel resultado = new JLabel("           ?          ");

        botao.addActionListener((e) -> {
            Thread thread = new Thread(() -> {
                long valor1 = Long.parseLong(primeiro.getText());
                long valor2 = Long.parseLong(segundo.getText());
                BigInteger calculo = new BigInteger("0");

                for (int i = 0; i < valor1; i++) {
                    for (int j = 0; j < valor2; j++) {
                        calculo = calculo.add(new BigInteger("1"));
                    }
                }

                resultado.setText(calculo.toString());
            });
            thread.start();
        });

        JPanel painel = new JPanel();
        painel.add(primeiro);
        painel.add(x);
        painel.add(segundo);
        painel.add(botao);
        painel.add(resultado);

        janela.add(painel);
        janela.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        janela.pack();
        janela.setVisible(true);
    }
}
