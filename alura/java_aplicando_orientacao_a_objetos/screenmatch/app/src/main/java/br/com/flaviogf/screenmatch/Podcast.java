package br.com.flaviogf.screenmatch;

public class Podcast extends Audio {
    public Podcast(String title, int duration, int views, int likes) {
        super(title, duration, views, likes);
    }

    @Override
    public void play() {
        System.out.println("Playing podcast: " + getTitle());
    }
}
