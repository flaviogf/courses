package br.com.flaviogf.weatherorama;

public interface Subject {
    void register(Observer observer);
    void unregister(Observer observer);
    void notifyObservers();
}
