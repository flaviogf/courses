package br.com.flaviogf.technews.models;

public class News {
    private final String id;
    private final String title;
    private final String content;

    public News(String id, String title, String content) {
        this.id = id;
        this.title = title;
        this.content = content;
    }

    public String getId() {
        return id;
    }

    public String getTitle() {
        return title;
    }

    public String getContent() {
        return content;
    }
}
