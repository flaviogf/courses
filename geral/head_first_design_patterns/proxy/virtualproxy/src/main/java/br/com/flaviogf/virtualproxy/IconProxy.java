package br.com.flaviogf.virtualproxy;

import javax.swing.*;
import java.awt.*;
import java.net.URL;

public class IconProxy implements Icon {
    private final URL url;
    private Icon icon;

    public IconProxy(URL url) {
        this.url = url;
    }

    public void paintIcon(Component c, Graphics g, int x, int y) {
        if (icon != null) {
            icon.paintIcon(c, g, x, y);
            return;
        }

        g.drawString("Loading CD Cover please wait ...", x + 300, y + 190);

        Thread thread = new Thread(() -> {
            icon = new ImageIcon(url, "CD Cover");
            c.repaint();
        });

        thread.start();
    }

    public int getIconWidth() {
        if (icon != null) {
            return icon.getIconWidth();
        }

        return 800;
    }

    public int getIconHeight() {
        if (icon != null) {
            return icon.getIconHeight();
        }

        return 600;
    }
}
