package br.com.flaviogf.decorator;

public class QuackCounter implements Quackable {
    private static Integer numberOfQuacks = 0;
    private final Quackable quackable;

    public QuackCounter(Quackable quackable) {
        this.quackable = quackable;
    }

    @Override
    public void quack() {
        quackable.quack();
        numberOfQuacks++;
    }

    public static Integer getNumberOfQuacks() {
        return numberOfQuacks;
    }
}
