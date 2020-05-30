package br.com.flaviogf.simpleremotecontrol;

public class SimpleRemoteControl {
    private Command slot;

    public void setCommand(Command command) {
        slot = command;
    }

    public void buttonWasPressed() {
        slot.execute();
    }
}
