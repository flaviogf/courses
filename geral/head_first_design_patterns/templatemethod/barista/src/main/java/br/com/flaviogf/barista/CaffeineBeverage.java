package br.com.flaviogf.barista;

public abstract class CaffeineBeverage {
    public void prepare() {
        boilWater();
        brew();
        pourInCup();
        addCondiments();
    }

    private void boilWater() {
        System.out.println("Boiling water");
    }

    private void pourInCup() {
        System.out.println("Pouring into cup");
    }

    protected abstract void brew();

    protected abstract void addCondiments();
}
