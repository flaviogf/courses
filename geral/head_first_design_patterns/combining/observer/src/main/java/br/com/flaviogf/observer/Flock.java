package br.com.flaviogf.observer;

import java.util.ArrayList;
import java.util.List;

public class Flock implements Quackable {
    private final List<Quackable> quackables = new ArrayList<>();

    public void add(Quackable quackable) {
        quackables.add(quackable);
    }

    @Override
    public void quack() {
        for (Quackable quackable : quackables) {
            quackable.quack();
        }
    }

    @Override
    public void registerObserver(Observer observer) {
        for (Quackable quackable : quackables) {
            quackable.registerObserver(observer);
        }
    }

    @Override
    public void notifyObservers() {
        for (Quackable quackable : quackables) {
            quackable.notifyObservers();
        }
    }
}
