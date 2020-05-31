package br.com.flaviogf.remote;

public class CeilingFan {
    private final static int HIGH = 3;
    private final static int MEDIUM = 2;
    private final static int LOW = 1;

    private int level;

    public void high() {
        System.out.println("CeilingFan::high");
        level = HIGH;
    }

    public void medium() {
        System.out.println("CeilingFan::medium");
        level = MEDIUM;
    }

    public void low() {
        System.out.println("CeilingFan::low");
        level = LOW;
    }

    public void off() {
        System.out.println("CeilingFan::off");
        level = 0;
    }

    public int getSpeed() {
        System.out.println("CeilingFan::getSpeed");
        return level;
    }
}
