package br.com.flaviogf.simpleremotecontrol;

public class RemoteControlTest {
    public static void main(String[] args) {
        SimpleRemoteControl control = new SimpleRemoteControl();

        Light light = new Light();
        LightOnCommand lightOnCommand = new LightOnCommand(light);

        GarageDoor garageDoor = new GarageDoor();
        GarageOpenCommand garageOpen = new GarageOpenCommand(garageDoor);

        control.setCommand(lightOnCommand);
        control.buttonWasPressed();

        control.setCommand(garageOpen);
        control.buttonWasPressed();
    }
}
