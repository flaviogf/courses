package br.com.flaviogf.adventure;

public class AxeBehavior implements WeaponBehavior {
    @Override
    public void useWeapon() {
        System.out.println("I'm using a axe...");
    }
}
