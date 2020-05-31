package br.com.flaviogf.remote;

public class GarageDownCommand implements Command {
    private final GarageDoor garageDoor;

    public GarageDownCommand(GarageDoor garageDoor) {
        this.garageDoor = garageDoor;
    }

    @Override
    public void execute() {
        garageDoor.down();
    }
}
