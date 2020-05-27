package br.com.flaviogf.pizzashop;

public class PizzaStore {

    private final SimpleFactoryPizza factory;

    public PizzaStore(SimpleFactoryPizza factory) {
        this.factory = factory;
    }

    public Pizza order(String cheese) {
        Pizza pizza = factory.create(cheese);

        pizza.prepare();
        pizza.bake();
        pizza.cut();
        pizza.bake();

        return pizza;
    }
}
