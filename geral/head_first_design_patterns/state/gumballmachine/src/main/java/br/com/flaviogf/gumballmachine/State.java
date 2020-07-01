package br.com.flaviogf.gumballmachine;

public interface State {
    void insertQuarter();

    void ejectQuarter();

    void turnCrank();

    void dispense();

    void refill();
}
