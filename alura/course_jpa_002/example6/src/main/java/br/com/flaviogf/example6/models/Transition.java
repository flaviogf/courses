package br.com.flaviogf.example6.models;

import java.math.BigDecimal;
import java.time.LocalDateTime;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
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

    public Account getTransition() {
        return account;
    }

    @Override
    public String toString() {
        return String.format("Transition[id=%d]", id);
    }
}