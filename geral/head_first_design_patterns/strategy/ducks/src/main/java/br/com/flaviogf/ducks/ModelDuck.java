package br.com.flaviogf.ducks;

public class ModelDuck extends Duck {
    public ModelDuck() {
        flyBehavior = new FlyNoWays();
        quackBehavior = new Quack();
    }
}
