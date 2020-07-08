package br.com.flaviogf.djview;

public class BeatController implements ControllerInterface {
    private final BeatModel model;
    private final DJView view;

    public BeatController(BeatModel model) {
        this.model = model;
        view = new DJView(this, model);
        view.createView();
        view.createControls();
        view.disableStopMenu();
        view.enableStartMenu();
        model.initialize();
    }

    @Override
    public void start() {
        model.on();
        view.disableStartMenu();
        view.enableStopMenu();
    }

    @Override
    public void stop() {
        model.off();
        view.disableStopMenu();
        view.enableStartMenu();
    }

    @Override
    public void increaseBPM() {
        Integer bpm = model.getBPM();
        model.setBPM(bpm + 1);
    }

    @Override
    public void decreaseBPM() {
        Integer bpm = model.getBPM();
        model.setBPM(bpm - 1);
    }

    @Override
    public void setBPM(Integer bpm) {
        model.setBPM(bpm);
    }
}
