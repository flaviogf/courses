package br.com.flaviogf.hometheater;

public class Amplifier {
    public void on() {
        System.out.println("Top-O-Line Amplifier on");
    }

    public void off() {
        System.out.println("Top-O-Line Amplifier off");
    }

    public void setCd() {
    }

    public void setDvd(DvdPlayer dvd) {
        System.out.println(String.format("Top-O-Line Amplifier setting DVD player to %s", dvd));
    }

    public void setStereoSound() {
    }

    public void setSurroundSound() {
        System.out.println("Top-O-Line Amplifier surround sound on (5 speakers, 1 subwoofer)");
    }

    public void setTuner() {
    }

    public void setVolume(int value) {
        System.out.println(String.format("Top-O-Line Amplifier setting volume to %d", value));
    }
}
