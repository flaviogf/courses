package br.com.flaviogf.gumballmachine;

public class HasQuarterState implements State {
    private final GumballMachine gumballMachine;

    public HasQuarterState(GumballMachine gumballMachine) {
        this.gumballMachine = gumballMachine;
    }

    @Override
    public void insertQuarter() {
        System.out.println("You cannot insert another quarter");
    }

    @Override
    public void ejectQuarter() {
        System.out.println("Quarter returned");

        gumballMachine.setState(gumballMachine.getNoQuarterState());
    }

    @Override
    public void turnCrank() {
        System.out.println("You turned ...");

        gumballMachine.setState(gumballMachine.getSoldState());
    }

    @Override
    public void dispense() {
        System.out.println("No gumball dispensed");
    }

    @Override
    public void refill() {

    }

    @Override
    public String toString() {
        return "waiting for turn of crank";
    }
}
