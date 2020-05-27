package br.com.flaviogf.pizzashop;

public class PizzaTestDrive {
    public static void main(String[] args) {
        SimpleFactoryPizza factory = new SimpleFactoryPizza();

        PizzaStore store = new PizzaStore(factory);

        Pizza pizza1 = store.order("cheese");
        System.out.println(pizza1);

        Pizza pizza2 = store.order("clam");
        System.out.println(pizza2);

        Pizza pizza3 = store.order("pepperoni");
        System.out.println(pizza3);

        Pizza pizza4 = store.order("veggie");
        System.out.println(pizza4);
    }
}
