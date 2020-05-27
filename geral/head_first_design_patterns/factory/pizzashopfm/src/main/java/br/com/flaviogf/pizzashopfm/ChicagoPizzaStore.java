package br.com.flaviogf.pizzashopfm;

public class ChicagoPizzaStore extends PizzaStore {
    @Override
    public Pizza create(String type) {
        if (type.equals("cheese")) {
            return new ChicagoStyleCheesePizza();
        }

        return null;
    }
}
