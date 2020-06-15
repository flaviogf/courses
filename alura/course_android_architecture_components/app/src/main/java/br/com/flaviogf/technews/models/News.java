package br.com.flaviogf.technews.models;

import java.util.UUID;

public class News {
    private final UUID id;
    private final String title;
    private final String content;

    public News(UUID id, String title, String content) {
        this.id = id;
        this.title = title;
        this.content = content;
    }

    public UUID getId() {
        return id;
    }

    public String getTitle() {
        return title;
    }

    public String getContent() {
        return content;
    }
}
