package br.com.flaviogf.pizzashopaf;

public class PizzaTestDrive {
    public static void main(String[] args) {
        PizzaStore nyStore = new NYPizzaStore();

        Pizza pizza1 = nyStore.orderPizza("cheese");
        Pizza pizza2 = nyStore.orderPizza("clam");

        System.out.println(pizza1);
        System.out.println(pizza2);
    }
}
