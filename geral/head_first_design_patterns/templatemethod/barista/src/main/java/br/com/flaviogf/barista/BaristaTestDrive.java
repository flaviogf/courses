package br.com.flaviogf.barista;

public class BaristaTestDrive {
    public static void main(String[] args) {
        System.out.println("Tea");
        CaffeineBeverage tea = new Tea();
        tea.prepare();

        System.out.println("Coffee");
        CaffeineBeverage coffee = new Coffee();
        coffee.prepare();

        System.out.println("Coffee with hook");
        CaffeineBeverageWithHook coffeeWithHook = new CoffeeWithHook();
        coffeeWithHook.prepare();
    }
}
