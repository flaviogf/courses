package br.com.flaviogf.pizzashopaf;

public class NYPizzaIngredientFactory implements PizzaIngredientFactory {
    public Dough createDough() {
        return new ThinCrustDough();
    }

    public Sauce createSauce() {
        return new MarinaraSauce();
    }

    public Cheese createCheese() {
        return new ReggianoCheese();
    }

    public Veggie[] createVeggies() {
        return new Veggie[]{new Garlic(), new Onion(), new Mushroom(), new RedPepper()};
    }

    public Pepperoni createPepperoni() {
        return new SlicedPepperoni();
    }

    public Clam createClam() {
        return new FreshClam();
    }
}
