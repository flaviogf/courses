package br.com.flaviogf.virtualproxy;

import java.awt.*;

public interface IconState {
    void paintIcon(Component c, Graphics g, int x, int y);

    int getIconWidth();

    int getIconHeight();
}
