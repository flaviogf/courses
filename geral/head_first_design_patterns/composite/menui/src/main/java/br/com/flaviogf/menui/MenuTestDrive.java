package br.com.flaviogf.menui;

import java.math.BigDecimal;

public class MenuTestDrive {
    public static void main(String[] args) {
        Menu pancakeMenuHouse = new Menu("PANCAKE HOUSE MENU", "Breakfast");
        Menu dinerMenu = new Menu("DINER MENU", "Lunch");
        Menu cafeMenu = new Menu("CAFE MENU", "Dinner");
        Menu dessertMenu = new Menu("DESSERT MENU", "Dessert of course!");

        Menu allMenus = new Menu("ALL MENUS", "All menus combined");

        allMenus.add(pancakeMenuHouse);
        allMenus.add(dinerMenu);
        allMenus.add(cafeMenu);

        pancakeMenuHouse.add(new MenuItem(
                "K&B's Pancake Breakfast",
                "Pancakes with scrambled eggs, and toast",
                true,
                new BigDecimal("2.99")
        ));

        pancakeMenuHouse.add(new MenuItem(
                "Regular Pancake Breakfast",
                "Pancakes with fried eggs, sausage",
                false,
                new BigDecimal("2.99")
        ));

        pancakeMenuHouse.add(new MenuItem(
                "Blueberry Pancakes",
                "Pancakes made with fresh blueberries, and blueberry syrup",
                true,
                new BigDecimal("3.49")
        ));

        pancakeMenuHouse.add(new MenuItem(
                "Waffles",
                "Waffles, with your choice of blueberries or strawberries",
                true,
                new BigDecimal("3.59")
        ));

        dinerMenu.add(new MenuItem(
                "Vegetarian BLT",
                "(Fakin') Bacon with lettuce & tomato on whole wheat",
                true,
                new BigDecimal("2.99")
        ));

        dinerMenu.add(new MenuItem(
                "BLT",
                "Bacon with lettuce & tomato on whole wheat",
                false,
                new BigDecimal("2.99")
        ));

        dinerMenu.add(new MenuItem(
                "Soup of the day",
                "A bowl of the soup of the day, with a side of potato salad",
                false,
                new BigDecimal("3.29")
        ));

        dinerMenu.add(new MenuItem(
                "Hot dog",
                "A hot dog with saurkraut, relish, onions, topped with cheese",
                false,
                new BigDecimal("3.05")
        ));

        dinerMenu.add(dessertMenu);

        dessertMenu.add(new MenuItem(
                "Apple pie",
                "Apple pie with a flakey crust, topped with vanilla icecream",
                true,
                new BigDecimal("1.59")
        ));

        dessertMenu.add(new MenuItem(
                "Cheesecake",
                "Creamy New York cheesecake with a chocolate graham, crust",
                true,
                new BigDecimal("1.99")
        ));

        Waitress waitress = new Waitress(allMenus);

        waitress.printVegetarianMenu();
    }
}
