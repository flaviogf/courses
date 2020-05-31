package br.com.flaviogf.remote;

public class GarageUpCommand implements Command {
    private final GarageDoor garageDoor;

    public GarageUpCommand(GarageDoor garageDoor) {
        this.garageDoor = garageDoor;
    }

    @Override
    public void execute() {
        garageDoor.up();
    }
}
