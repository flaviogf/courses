package br.com.flaviogf.pizzashopfm;

public abstract class PizzaStore {
    public Pizza order(String type) {
        Pizza pizza = create(type);

        pizza.prepare();
        pizza.bake();
        pizza.cut();
        pizza.box();

        return pizza;
    }

    protected abstract Pizza create(String type);
}
