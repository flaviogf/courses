package br.com.flaviogf.djview;

import javax.sound.midi.*;
import java.util.ArrayList;
import java.util.List;

public class BeatModel implements BeatModelInterface, MetaEventListener {
    private Sequencer sequencer;
    private Sequence sequence;
    private Track track;
    private Integer bpm = 90;
    private List<BeatObserver> beatObservers = new ArrayList<>();
    private List<BPMObserver> bpmObservers = new ArrayList<>();

    @Override
    public void initialize() {
        setUpMidi();
        buildTrackAndStart();
    }

    @Override
    public void on() {
        System.out.println("Starting the sequencer");
        sequencer.start();
        setBPM(90);
    }

    @Override
    public void off() {
        setBPM(0);
        sequencer.stop();
    }

    @Override
    public void setBPM(Integer bpm) {
        this.bpm = bpm;
        sequencer.setTempoInBPM(getBPM());
        notifyBPMObservers();
    }

    @Override
    public Integer getBPM() {
        return bpm;
    }

    @Override
    public void registerObserver(BeatObserver observer) {
        beatObservers.add(observer);
    }

    @Override
    public void registerObserver(BPMObserver observer) {
        bpmObservers.add(observer);
    }

    @Override
    public void removeObserver(BeatObserver observer) {
        beatObservers.remove(observer);
    }

    @Override
    public void removeObserver(BPMObserver observer) {
        bpmObservers.add(observer);
    }

    @Override
    public void meta(MetaMessage meta) {
        if (meta.getType() != 47) {
            return;
        }

        notifyBeatObservers();
        sequencer.start();
        setBPM(getBPM());
    }

    private void setUpMidi() {
        try {
            sequencer = MidiSystem.getSequencer();
            sequencer.open();
            sequencer.addMetaEventListener(this);
            sequence = new Sequence(Sequence.PPQ, 4);
            track = sequence.createTrack();
            sequencer.setTempoInBPM(getBPM());
            sequencer.setLoopCount(Sequencer.LOOP_CONTINUOUSLY);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void buildTrackAndStart() {
        int[] tracks = {35, 0, 46, 0};

        sequence.deleteTrack(null);

        track = sequence.createTrack();

        mackTracks(tracks);

        track.add(makeEvent(192, 9, 1, 0, 4));

        try {
            sequencer.setSequence(sequence);
        } catch (InvalidMidiDataException e) {
            e.printStackTrace();
        }
    }

    private void mackTracks(int[] tracks) {
        for (int i = 1; i < tracks.length; i++) {
            int key = tracks[i];
            track.add(makeEvent(144, 9, key, 100, i));
            track.add(makeEvent(128, 9, key, 100, i + 1));
        }
    }

    private MidiEvent makeEvent(int command, int channel, int one, int two, int tick) {
        ShortMessage message = new ShortMessage();

        try {
            message.setMessage(command, channel, one, two);
        } catch (InvalidMidiDataException e) {
            e.printStackTrace();
        }

        return new MidiEvent(message, tick);
    }

    private void notifyBeatObservers() {
        for (BeatObserver observer : beatObservers) {
            observer.updateBeat();
        }
    }

    private void notifyBPMObservers() {
        for (BPMObserver observer : bpmObservers) {
            observer.updateBPM();
        }
    }
}
