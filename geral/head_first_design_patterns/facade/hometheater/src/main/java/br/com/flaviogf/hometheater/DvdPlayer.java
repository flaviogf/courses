package br.com.flaviogf.hometheater;

public class DvdPlayer {
    private String movie;

    public void on() {
        System.out.println("Top-O-Line DVD Player on");
    }

    public void off() {
        System.out.println("Top-O-Line DVD Player off");
    }

    public void eject() {
        System.out.println("Top-O-Line DVD Player eject");
    }

    public void pause() {
    }

    public void play(String movie) {
        System.out.println(String.format("Top-O-Line DVD Player playing %s", movie));

        this.movie = movie;
    }

    public void setSurroundAudio() {
    }

    public void setTwoChannelAudio() {
    }

    public void stop() {
        System.out.println(String.format("Top-O-Line DVD Player stopped %s", movie));
    }

    @Override
    public String toString() {
        return "Top-O-Line DVD Player";
    }
}
