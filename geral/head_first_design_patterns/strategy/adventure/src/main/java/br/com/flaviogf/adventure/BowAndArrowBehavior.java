package br.com.flaviogf.adventure;

public class BowAndArrowBehavior implements WeaponBehavior {
    @Override
    public void useWeapon() {
        System.out.println("I'm using bow and arrow...");
    }
}
