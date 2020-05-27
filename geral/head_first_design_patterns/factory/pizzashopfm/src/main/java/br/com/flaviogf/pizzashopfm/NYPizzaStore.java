package br.com.flaviogf.pizzashopfm;

public class NYPizzaStore extends PizzaStore {
    @Override
    public Pizza create(String type) {
        if (type.equals("cheese")) {
            return new NYStyleCheesePizza();
        }

        return null;
    }
}
