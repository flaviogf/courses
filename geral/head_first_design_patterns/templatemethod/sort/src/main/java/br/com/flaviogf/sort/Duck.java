package br.com.flaviogf.sort;

public class Duck implements Comparable<Duck> {
    private final String name;
    private final Double weight;

    public Duck(String name, Double weight) {
        this.name = name;
        this.weight = weight;
    }

    @Override
    public String toString() {
        return String.format("Duck(name='%s', weight=%.2f)", name, weight);
    }

    @Override
    public int compareTo(Duck duck) {
        return weight.compareTo(duck.weight);
    }
}
