package br.com.flaviogf.adventure;

public class SwordBehavior implements WeaponBehavior {
    @Override
    public void useWeapon() {
        System.out.println("I'm using a sword...");
    }
}
