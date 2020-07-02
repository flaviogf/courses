package br.com.flaviogf.virtualproxy;

import javax.swing.*;
import java.awt.*;
import java.net.URL;

public class IconProxy implements Icon {
    private final IconState loaded;
    private final IconState notLoaded;
    private final URL url;
    private IconState state;
    private Icon icon;

    public IconProxy(URL url) {
        this.url = url;
        loaded = new Loaded(this);
        notLoaded = new NotLoaded(this);
        state = notLoaded;
    }

    public URL getUrl() {
        return url;
    }

    public void setState(IconState state) {
        this.state = state;
    }

    public Icon getIcon() {
        return icon;
    }

    public void setIcon(Icon icon) {
        this.icon = icon;
    }

    public void paintIcon(Component c, Graphics g, int x, int y) {
        state.paintIcon(c, g, x, y);
    }

    public int getIconWidth() {
        return state.getIconWidth();
    }

    public int getIconHeight() {
        return state.getIconHeight();
    }

    public IconState getLoaded() {
        return loaded;
    }

    public IconState getNotLoaded() {
        return notLoaded;
    }
}
