package br.com.flaviogf.djview;

public interface BeatModelInterface {
    void initialize();

    void on();

    void off();

    void setBPM(Integer bpm);

    Integer getBPM();

    void registerObserver(BeatObserver observer);

    void registerObserver(BPMObserver observer);

    void removeObserver(BeatObserver observer);

    void removeObserver(BPMObserver observer);
}
