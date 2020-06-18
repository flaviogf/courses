package br.com.flaviogf.barista;

import java.util.Scanner;

public class CoffeeWithHook extends CaffeineBeverageWithHook {
    @Override
    protected void brew() {
        System.out.println("Dripping coffee through filter");
    }

    @Override
    protected void addCondiments() {
        System.out.println("Adding sugar and milk");
    }

    @Override
    protected boolean customerWantsCondiments() {
        String answer = getUserInput();

        return answer.equalsIgnoreCase("y");
    }

    private String getUserInput() {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Answer (y) or (n) whether you want to add condiments in your beverage");

        return scanner.nextLine();
    }
}
