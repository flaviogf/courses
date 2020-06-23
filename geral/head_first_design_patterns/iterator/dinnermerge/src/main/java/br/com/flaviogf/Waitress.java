package br.com.flaviogf;

public class Waitress {
    private final Menu pancakeHouseMenu;
    private final Menu dinnerMenu;

    public Waitress(Menu pancakeHouseMenu, Menu dinnerMenu) {
        this.pancakeHouseMenu = pancakeHouseMenu;
        this.dinnerMenu = dinnerMenu;
    }

    public void printMenus() {
        System.out.println("MENU");
        System.out.println("----");

        Iterator<MenuItem> pancakeMenuHouseIterator = pancakeHouseMenu.iterator();
        System.out.println("BREAKFAST");
        printMenu(pancakeMenuHouseIterator);

        System.out.println();

        System.out.println("Lunch");
        Iterator<MenuItem> dinnerMenuIterator = dinnerMenu.iterator();
        printMenu(dinnerMenuIterator);
    }

    private void printMenu(Iterator<MenuItem> iterator) {
        while (iterator.hasNext()) {
            System.out.println(iterator.next());
        }
    }
}
