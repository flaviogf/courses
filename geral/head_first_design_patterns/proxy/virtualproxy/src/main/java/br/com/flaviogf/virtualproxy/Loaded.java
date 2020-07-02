package br.com.flaviogf.virtualproxy;

import java.awt.*;

public class Loaded implements IconState {
    private final IconProxy iconProxy;

    public Loaded(IconProxy iconProxy) {
        this.iconProxy = iconProxy;
    }

    @Override
    public void paintIcon(Component c, Graphics g, int x, int y) {
        iconProxy.getIcon().paintIcon(c, g, x, y);
    }

    @Override
    public int getIconWidth() {
        return iconProxy.getIcon().getIconWidth();
    }

    @Override
    public int getIconHeight() {
        return iconProxy.getIcon().getIconHeight();
    }
}
