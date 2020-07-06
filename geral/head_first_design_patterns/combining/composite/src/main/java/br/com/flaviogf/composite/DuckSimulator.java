package br.com.flaviogf.composite;

public class DuckSimulator {
    public static void main(String[] args) {
        DuckSimulator simulator = new DuckSimulator();
        simulator.simulate();
    }

    private void simulate() {
        AbstractDuckFactory abstractDuckFactory = new CountingDuckFactory();

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

        Quackable mallardDuck1 = abstractDuckFactory.createMallardDuck();
        Quackable mallardDuck2 = abstractDuckFactory.createMallardDuck();
        Quackable mallardDuck3 = abstractDuckFactory.createMallardDuck();
        Quackable mallardDuck4 = abstractDuckFactory.createMallardDuck();

        Flock flockOfMallards = new Flock();
        flockOfMallards.add(mallardDuck1);
        flockOfMallards.add(mallardDuck2);
        flockOfMallards.add(mallardDuck3);
        flockOfMallards.add(mallardDuck4);

        flockOfDucks.add(flockOfMallards);

        simulate(flockOfDucks);

        System.out.println(String.format("Number of quacks: %d", QuackCounter.getNumberOfQuacks()));
    }

    private void simulate(Quackable quackable) {
        quackable.quack();
    }
}
