package br.com.flaviogf.dinnermergei;

import java.util.Arrays;
import java.util.List;

public class MenuTestDrive {
    public static void main(String[] args) {
        Menu pancakeHouseMenu = new PancakeHouseMenu();
        Menu cafeMenu = new CafeMenu();

        List<Menu> menus = Arrays.asList(pancakeHouseMenu, cafeMenu);

        Waitress waitress = new Waitress(menus);

        waitress.printMenus();
    }
}
