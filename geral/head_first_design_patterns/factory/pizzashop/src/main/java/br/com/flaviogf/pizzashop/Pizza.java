package br.com.flaviogf.pizzashop;

public abstract class Pizza {
    private final String name;

    public Pizza(String name) {
        this.name = name;
    }

    public void prepare() {
        System.out.println(String.format("[%s]: preparing...", name));
    }

    public void bake() {
        System.out.println(String.format("[%s]: baking...", name));
    }

    public void cut() {
        System.out.println(String.format("[%s]: cutting...", name));
    }

    public void box() {
        System.out.println(String.format("[%s]: boxing...", name));
    }

    @Override
    public String toString() {
        return name;
    }
}
