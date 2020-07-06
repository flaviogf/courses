package br.com.flaviogf.observer;

public interface QuackObservable {
    void registerObserver(Observer observer);

    void notifyObservers();
}
