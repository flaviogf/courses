package br.com.flaviogf.example5.models;

import java.math.BigDecimal;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToMany;
import javax.persistence.ManyToOne;

@Entity
public class Transition {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    private String description;
    private LocalDateTime date;
    private BigDecimal value;
    @ManyToOne
    private Account account;
    @ManyToMany
    private List<Category> categories = new ArrayList<>();

    @Deprecated
    public Transition() {
    }

    public Transition(String description, LocalDateTime date, BigDecimal value, Account account) {
        this.description = description;
        this.date = date;
        this.value = value;
        this.account = account;
    }

    public Integer getId() {
        return id;
    }

    public String getDescription() {
        return description;
    }

    public LocalDateTime getDate() {
        return date;
    }

    public BigDecimal getValue() {
        return value;
    }

    public void add(Category category) {
        categories.add(category);
    }
}