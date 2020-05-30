package br.com.flaviogf.simpleremotecontrol;

public class GarageOpenCommand implements Command {
    private final GarageDoor garageDoor;

    public GarageOpenCommand(GarageDoor garageDoor) {
        this.garageDoor = garageDoor;
    }

    @Override
    public void execute() {
        garageDoor.up();
    }
}
