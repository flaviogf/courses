package br.com.flaviogf.observer;

public class DuckSimulator {
    public static void main(String[] args) {
        DuckSimulator simulator = new DuckSimulator();
        simulator.simulate();
    }

    private void simulate() {
        AbstractDuckFactory abstractDuckFactory = new DuckFactory();

        Quackable mallardDuck = abstractDuckFactory.createMallardDuck();
        Quackable redheadDuck = abstractDuckFactory.createRedheadDuck();
        Quackable duckCall = abstractDuckFactory.createDuckCall();
        Quackable rubberDuck = abstractDuckFactory.createRubberDuck();
        GooseAdapter gooseDuck = new GooseAdapter(new Goose());

        Flock flockOfDucks = new Flock();
        flockOfDucks.add(mallardDuck);
        flockOfDucks.add(redheadDuck);
        flockOfDucks.add(duckCall);
        flockOfDucks.add(rubberDuck);
        flockOfDucks.add(gooseDuck);

        flockOfDucks.registerObserver((it) -> System.out.println(String.format("Quacklogist: %s just quacked", it)));

        simulate(flockOfDucks);
    }

    private void simulate(Quackable quackable) {
        quackable.quack();
    }
}
