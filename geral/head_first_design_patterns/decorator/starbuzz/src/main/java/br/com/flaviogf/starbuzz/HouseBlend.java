package br.com.flaviogf.starbuzz;

public class HouseBlend extends Beverage {
    public HouseBlend() {
        description = "House Blend Coffee";
    }

    @Override
    public double getCost() {
        return 0.89;
    }
}
