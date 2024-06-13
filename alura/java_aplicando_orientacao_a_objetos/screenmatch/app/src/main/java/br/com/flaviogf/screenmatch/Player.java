package br.com.flaviogf.screenmatch;

import java.util.ArrayList;
import java.util.List;

public class Player {
    private final List<Audio> audios;

    public Player() {
        this(new ArrayList<>());
    }

    public Player(List<Audio> audios) {
        this.audios = audios;
    }

    public void add(Audio audio) {
        audios.add(audio);
    }

    public void play() {
        audios.stream().sorted().forEach(Audio::play);
    }

    public static void main(String[] args) {
        Player player = new Player();
        player.add(new Podcast("Podcast 1", 100, 100, 100));
        player.add(new Music("Music 1", 100, 100, 100));
        player.play();
    }
}
