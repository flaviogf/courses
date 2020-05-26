package br.com.flaviogf.starbuzz;

public class StarbuzzCoffee {
    public static void main(String[] args) {
        Beverage beverage1 = new Espresso();

        System.out.println(beverage1.getDescription() + ", $" + beverage1.getCost());

        Beverage beverage2 = new HouseBlend();
        beverage2 = new Soy(beverage2);
        beverage2 = new Mocha(beverage2);
        beverage2 = new Whip(beverage2);

        System.out.println(beverage2.getDescription() + ", $" + beverage2.getCost());
    }
}
