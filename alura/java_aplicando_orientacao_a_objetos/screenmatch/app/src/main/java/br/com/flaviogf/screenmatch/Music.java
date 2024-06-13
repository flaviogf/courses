package br.com.flaviogf.screenmatch;

public class Music extends Audio {
    public Music(String title, int duration, int views, int likes) {
        super(title, duration, views, likes);
    }

    @Override
    public void play() {
        System.out.println("Playing music: " + getTitle());
    }
}
