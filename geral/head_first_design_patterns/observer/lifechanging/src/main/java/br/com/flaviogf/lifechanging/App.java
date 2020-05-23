package br.com.flaviogf.lifechanging;

import javax.swing.*;
import java.awt.*;

import static javax.swing.JFrame.EXIT_ON_CLOSE;

public class App {
    public static void main(String[] args) {
        JFrame frame = new JFrame();
        frame.setSize(300, 300);
        frame.setDefaultCloseOperation(EXIT_ON_CLOSE);
        frame.setVisible(true);

        JButton button = new JButton("Should I do it?");
        button.addActionListener((e) -> System.out.println("Don't do it, you might regret it"));
        button.addActionListener((e) -> System.out.println("Come on, do it"));

        frame.getContentPane().add(BorderLayout.CENTER, button);
    }
}
