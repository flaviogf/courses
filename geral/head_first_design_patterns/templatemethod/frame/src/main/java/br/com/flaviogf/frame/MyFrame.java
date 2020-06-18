package br.com.flaviogf.frame;

import javax.swing.*;
import java.awt.*;

public class MyFrame extends JFrame {
    public MyFrame(String title) {
        super(title);

        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(300, 300);
        setVisible(true);
    }

    @Override
    public void paint(Graphics g) {
        super.paint(g);
        g.drawString("I rule!", 100, 100);
    }

    public static void main(String[] args) {
        MyFrame frame = new MyFrame("Head First Design Pattern");
    }
}
