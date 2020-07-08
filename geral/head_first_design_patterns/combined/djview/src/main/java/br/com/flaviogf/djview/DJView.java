package br.com.flaviogf.djview;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class DJView implements ActionListener, BeatObserver, BPMObserver {
    private final ControllerInterface controller;
    private final BeatModelInterface model;
    private JPanel viewPanel;
    private JFrame viewFrame;
    private JLabel bpmOutputLabel;
    private JFrame controlFrame;
    private JPanel controlPanel;
    private JMenuBar menuBar;
    private JMenu menu;
    private JMenuItem startMenuItem;
    private JMenuItem stopMenuItem;
    private JMenuItem exitMenuItem;
    private JTextField bpmTextField;
    private JLabel bpmLabel;
    private JButton setBpmButton;
    private JButton increaseButton;
    private JButton decreaseButton;
    private BeatBar beatBar;

    public DJView(ControllerInterface controller, BeatModelInterface model) {
        this.controller = controller;
        this.model = model;
        model.registerObserver((BeatObserver) this);
        model.registerObserver((BPMObserver) this);
    }

    public void createView() {
        viewPanel = new JPanel(new GridLayout(1, 2));
        viewFrame = new JFrame("View");
        viewFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        viewFrame.setSize(new Dimension(100, 80));
        bpmOutputLabel = new JLabel();
        beatBar = new BeatBar();
        beatBar.setValue(0);
        JPanel bpmPanel = new JPanel(new GridLayout(2, 1));
        bpmPanel.add(beatBar);
        bpmPanel.add(bpmOutputLabel);
        viewPanel.add(bpmPanel);
        viewFrame.getContentPane().add(viewPanel, BorderLayout.CENTER);
        viewFrame.pack();
        viewFrame.setVisible(true);
    }

    public void createControls() {
        JFrame.setDefaultLookAndFeelDecorated(true);
        controlFrame = new JFrame("Controls");
        controlFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        controlFrame.setSize(new Dimension(100, 80));

        controlPanel = new JPanel(new GridLayout(1, 2));

        menu = new JMenu("DJ Menu");
        startMenuItem = new JMenuItem("Start");
        menu.add(startMenuItem);
        startMenuItem.addActionListener((it) -> controller.start());
        stopMenuItem = new JMenuItem("Stop");
        menu.add(stopMenuItem);
        stopMenuItem.addActionListener((it) -> controller.stop());
        exitMenuItem = new JMenuItem("Exit");
        menu.add(exitMenuItem);
        exitMenuItem.addActionListener((it) -> System.exit(0));
        menuBar = new JMenuBar();
        menuBar.add(menu);
        controlFrame.setJMenuBar(menuBar);

        bpmTextField = new JTextField(2);
        bpmLabel = new JLabel("Enter BPM", SwingConstants.RIGHT);
        setBpmButton = new JButton("Set");
        setBpmButton.setSize(new Dimension(10, 40));
        increaseButton = new JButton(">>");
        decreaseButton = new JButton("<<");
        setBpmButton.addActionListener(this);
        increaseButton.addActionListener(this);
        decreaseButton.addActionListener(this);
        JPanel buttonPanel = new JPanel(new GridLayout(1, 2));
        buttonPanel.add(decreaseButton);
        buttonPanel.add(increaseButton);

        JPanel enterPanel = new JPanel(new GridLayout(1, 2));
        enterPanel.add(bpmLabel);
        enterPanel.add(bpmTextField);
        JPanel insideControlPanel = new JPanel(new GridLayout(3, 1));
        insideControlPanel.add(enterPanel);
        insideControlPanel.add(setBpmButton);
        insideControlPanel.add(buttonPanel);
        controlPanel.add(insideControlPanel);

        bpmLabel.setBorder(BorderFactory.createEmptyBorder(5, 5, 5, 5));
        bpmOutputLabel.setBorder(BorderFactory.createEmptyBorder(5, 5, 5, 5));

        controlFrame.getRootPane().setDefaultButton(setBpmButton);
        controlFrame.getContentPane().add(controlPanel, BorderLayout.CENTER);

        controlFrame.pack();
        controlFrame.setVisible(true);
    }

    public void enableStopMenu() {
        stopMenuItem.setEnabled(true);
    }

    public void disableStopMenu() {
        stopMenuItem.setEnabled(false);
    }

    public void enableStartMenu() {
        startMenuItem.setEnabled(true);
    }

    public void disableStartMenu() {
        startMenuItem.setEnabled(false);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        if (e.getSource() == setBpmButton) {
            Integer bpm = Integer.parseInt(bpmTextField.getText());
            controller.setBPM(bpm);
            return;
        }

        if (e.getSource() == increaseButton) {
            controller.increaseBPM();
            return;
        }

        if (e.getSource() == decreaseButton) {
            controller.decreaseBPM();
        }
    }

    @Override
    public void updateBeat() {
        if (model == null) {
            return;
        }

        if (bpmOutputLabel == null) {
            return;
        }

        Integer bpm = model.getBPM();

        if (bpm == 0) {
            bpmOutputLabel.setText("Offline");
            return;
        }

        bpmOutputLabel.setText(String.format("Current BPM %d", bpm));
    }

    @Override
    public void updateBPM() {
        if (beatBar == null) {
            return;
        }

        beatBar.setValue(100);
    }
}
