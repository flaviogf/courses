package br.com.flaviogf.menu;

import java.math.BigDecimal;

public class MenuTestDrive {
    public static void main(String[] args) {
        Menu pancakeHouse = new Menu("PANCAKE HOUSE MENU", "Breakfast");
        Menu dinerMenu = new Menu("DINER MENU", "Lunch");
        Menu cafeMenu = new Menu("CAFE MENU", "Dinner");
        Menu dessertMenu = new Menu("DESSERT MENU", "Dessert of course");

        Menu allMenus = new Menu("ALL MENUS", "All menus combined");

        allMenus.add(pancakeHouse);
        allMenus.add(dinerMenu);
        allMenus.add(cafeMenu);

        dinerMenu.add(new MenuItem(
                "Pasta",
                "Spaghetti with marinara sauce, and slice of sourdough bread",
                true,
                new BigDecimal("3.89")
        ));

        dinerMenu.add(dessertMenu);

        Waitress waitress = new Waitress(allMenus);

        waitress.printMenu();
    }
}
