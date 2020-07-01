package br.com.flaviogf.gumballmachine;

public class GumballMachine {
    private final State soldOutState;
    private final State noQuarterState;
    private final State hasQuarterState;
    private final State soldState;
    private State state;
    private Integer count;

    public GumballMachine(Integer count) {
        soldOutState = new SoldOutState(this);
        noQuarterState = new NoQuarterState(this);
        hasQuarterState = new HasQuarterState(this);
        soldState = new SoldOutState(this);
        state = count > 0 ? hasQuarterState : soldOutState;
        this.count = count;
    }

    public void insertQuarter() {
        state.insertQuarter();
    }

    public void ejectQuarter() {
        state.ejectQuarter();
    }

    public void turnCrank() {
        state.turnCrank();
    }

    public void dispense() {
        state.dispense();
    }

    public void refill(Integer count) {
        this.count += count;

        state.refill();
    }

    public void releaseBall() {
        if (count <= 0) return;

        count--;
    }

    public State getSoldOutState() {
        return soldOutState;
    }

    public State getNoQuarterState() {
        return noQuarterState;
    }

    public State getHasQuarterState() {
        return hasQuarterState;
    }

    public State getSoldState() {
        return soldState;
    }

    public void setState(State state) {
        this.state = state;
    }

    public Integer getCount() {
        return count;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();

        sb.append("\nMighty Gumball, Inc.");
        sb.append("\nJava-enabled Standing Gumball Model #2004");
        sb.append("\nInventory: ").append(count).append(" gumball");

        if (count != 1) {
            sb.append("s");
        }

        sb.append("\nMachine is ").append(state).append("\n");

        return sb.toString();
    }
}
