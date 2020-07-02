package br.com.flaviogf.virtualproxy;

import javax.swing.*;
import java.awt.*;

public class NotLoaded implements IconState {
    private final IconProxy iconProxy;

    public NotLoaded(IconProxy iconProxy) {
        this.iconProxy = iconProxy;
    }

    @Override
    public void paintIcon(Component c, Graphics g, int x, int y) {
        g.drawString("Loading CD Cover please wait ...", x + 300, y + 190);

        Thread thread = new Thread(() -> {
            iconProxy.setIcon(new ImageIcon(iconProxy.getUrl(), "CD Cover"));
            iconProxy.setState(iconProxy.getLoaded());
            c.repaint();
        });

        thread.start();
    }

    @Override
    public int getIconWidth() {
        return 800;
    }

    @Override
    public int getIconHeight() {
        return 600;
    }
}
