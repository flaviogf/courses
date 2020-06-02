package br.com.flaviogf.ducks;

public class DuckTestDrive {
    public static void main(String[] args) {
        MallardDuck mallard = new MallardDuck();

        System.out.println("The duck says");
        mallard.quack();
        mallard.fly();

        WildTurkey wild = new WildTurkey();

        System.out.println("The turkey says");
        wild.gobble();
        wild.fly();

        TurkeyAdapter turkeyAdapter = new TurkeyAdapter(wild);
        System.out.println("The turkey adapter says");
        testDuck(turkeyAdapter);
    }

    private static void testDuck(Duck duck) {
        duck.quack();
        duck.fly();
    }
}
