package br.com.flaviogf.barista;

public abstract class CaffeineBeverageWithHook {
    public void prepare() {
        boilWater();
        brew();
        pourInCup();
        if (customerWantsCondiments()) {
            addCondiments();
        }
    }

    private void boilWater() {
        System.out.println("Boiling water");
    }

    private void pourInCup() {
        System.out.println("Pouring into cup");
    }

    protected abstract void brew();

    protected boolean customerWantsCondiments() {
        return true;
    }

    protected abstract void addCondiments();
}
