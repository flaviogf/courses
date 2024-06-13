package br.com.flaviogf.screenmatch;

public abstract class Audio implements Comparable<Audio> {
    private final String title;
    private final int duration;
    private final int views;
    private final int likes;

    public Audio(String title, int duration, int views, int likes) {
        this.title = title;
        this.duration = duration;
        this.views = views;
        this.likes = likes;
    }

    public String getTitle() {
        return title;
    }

    public int getDuration() {
        return duration;
    }

    public int getViews() {
        return views;
    }

    public int getLikes() {
        return likes;
    }

    public abstract void play();

    @Override
    public int compareTo(Audio other) {
        return title.compareTo(other.title);
    }
}
