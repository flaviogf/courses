package br.com.flaviogf.adventure;

public class App {
    public static void main(String[] args) {
        Character knight = new Knight();
        knight.setWeaponBehavior(new AxeBehavior());
        knight.fight();
        knight.setWeaponBehavior(new SwordBehavior());
        knight.fight();
    }
}
