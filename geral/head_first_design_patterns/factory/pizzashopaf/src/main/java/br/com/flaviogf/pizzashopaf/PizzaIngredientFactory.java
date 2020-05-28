package br.com.flaviogf.pizzashopaf;

public interface PizzaIngredientFactory {
    Dough createDough();

    Sauce createSauce();

    Cheese createCheese();

    Veggie[] createVeggies();

    Pepperoni createPepperoni();

    Clam createClam();
}
