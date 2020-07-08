package br.com.flaviogf.djview;

import javax.swing.*;

public class BeatBar extends JProgressBar implements Runnable {
    private final Thread thread;

    public BeatBar() {
        thread = new Thread(this);

        setMaximum(100);

        thread.start();
    }

    @Override
    public void run() {
        while (true) {
            int newValue = (int) (getValue() * 0.75);

            setValue(newValue);

            repaint();

            try {
                Thread.sleep(50);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }
}
