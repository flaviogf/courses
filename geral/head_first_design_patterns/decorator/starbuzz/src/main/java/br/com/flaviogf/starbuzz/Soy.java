package br.com.flaviogf.starbuzz;

public class Soy extends CondimentDecorator {
    private final Beverage beverage;

    public Soy(Beverage beverage) {
        this.beverage = beverage;
    }

    @Override
    public String getDescription() {
        return beverage.getDescription() + ", Soy";
    }

    @Override
    public double getCost() {
        return 0.15 + beverage.getCost();
    }
}
