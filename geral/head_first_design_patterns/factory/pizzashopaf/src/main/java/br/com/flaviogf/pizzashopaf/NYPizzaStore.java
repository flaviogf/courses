package br.com.flaviogf.pizzashopaf;

public class NYPizzaStore extends PizzaStore {
    protected Pizza createPizza(String type) {
        if (type.equals("cheese")) {
            Pizza cheesePizza = new CheesePizza(new NYPizzaIngredientFactory());
            cheesePizza.setName("New York Style Cheese Pizza");
            return cheesePizza;
        }

        if (type.equals("clam")) {
            Pizza clamPizza = new ClamPizza(new NYPizzaIngredientFactory());
            clamPizza.setName("New York Style Clam Pizza");
            return clamPizza;
        }

        return null;
    }
}
