package br.com.flaviogf.hometheater;

public class TheaterLights {
    public void on() {
        System.out.println("Theater Ceiling Lights on");
    }

    public void off() {
    }

    public void dim(int value) {
        System.out.println(String.format("Theater Ceiling Lights dimming to %d%%", value));
    }
}
