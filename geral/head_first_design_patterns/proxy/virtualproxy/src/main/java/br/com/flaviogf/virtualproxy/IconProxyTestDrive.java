package br.com.flaviogf.virtualproxy;

import javax.swing.*;
import java.net.URL;
import java.util.HashMap;
import java.util.Map;
import java.util.function.Function;

public class IconProxyTestDrive {
    private static final Map<String, String> cds = new HashMap<>();

    public static void main(String[] args) throws Exception {
        cds.put("Buddha Bar", "http://images.amazon.com/images/P/B00009XBYK.01.LZZZZZZZ.jpg");
        cds.put("Ima", "http://images.amazon.com/images/P/B000005IRM.01.LZZZZZZZ.jpg");
        cds.put("Karma", "http://images.amazon.com/images/P/B000005DCB.01.LZZZZZZZ.gif");
        cds.put("MCMXC A.D.", "http://images.amazon.com/images/P/B000002URV.01.LZZZZZZZ.jpg");
        cds.put("Northern Exposure", "http://images.amazon.com/images/P/B000003SFN.01.LZZZZZZZ.jpg");
        cds.put("Selected Ambient Works, Vol. 2", "http://images.amazon.com/images/P/B000002MNZ.01.LZZZZZZZ.jpg");

        Icon icon = new IconProxy(new URL("http://images.amazon.com/images/P/B000002MNZ.01.LZZZZZZZ.jpg"));

        ImageContainer container = new ImageContainer(icon);

        JMenu favorites = new JMenu("Favorites");

        cds.entrySet().stream().map(menuItem(container)).forEach(favorites::add);

        JMenuBar menuBar = new JMenuBar();
        menuBar.add(favorites);

        JFrame frame = new JFrame("CD Cover Viewer");
        frame.setJMenuBar(menuBar);

        frame.getContentPane().add(container);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(800, 600);
        frame.setVisible(true);
    }

    private static Function<Map.Entry<String, String>, JMenuItem> menuItem(ImageContainer component) {
        return (it) -> {
            String name = it.getKey();

            String url = it.getValue();

            JMenuItem item = new JMenuItem(name);

            item.addActionListener((view) -> {
                try {
                    component.setIcon(new IconProxy(new URL(url)));
                } catch (Exception e) {
                    e.printStackTrace();
                }
            });

            return item;
        };
    }
}
