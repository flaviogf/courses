package br.com.flaviogf;

public class Book {
    private String title;
    private String author;
    private String description;

    public Book(String title, String author, String description) {
        this.title = title;
        this.author = author;
        this.description = description;
    }

    @Override
    public String toString() {
        if (description.length() <= 30) {
            return String.format("Title: %s\nAuthor: %s\nDescription:%s", title, author, description);
        }

        return String.format("Title: %s\nAuthor: %s\nDescription:%s", title, author, description.substring(0, 27) + "...");
    }
}
