package br.com.flaviogf.decorator;

public class RedheadDuck implements Quackable {
    @Override
    public void quack() {
        System.out.println("Quack");
    }
}
