package br.com.flaviogf.pizzashopfm;

public class PizzaTestDrive {
    public static void main(String[] args) {
        PizzaStore nyStore = new NYPizzaStore();
        Pizza pizza1 = nyStore.order("cheese");
        System.out.println("Ethan ordered a pizza " + pizza1.getName() + "\n");

        PizzaStore chicagoStore = new ChicagoPizzaStore();
        Pizza pizza2 = chicagoStore.order("cheese");
        System.out.println("Joel ordered a pizza " + pizza2.getName() + "\n");
    }
}
