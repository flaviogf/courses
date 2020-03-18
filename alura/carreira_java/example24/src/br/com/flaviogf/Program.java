package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Employee employee1 = new Employee("Frank", "123", 1000);
        Employee employee2 = new Manager("Fernando", "456", 1000);
        Employee employee3 = new VideoEditor("Flavio", "789", 1000);

        BonusController controller = new BonusController();

        controller.register(employee1, employee2, employee3);

        System.out.println(controller.getTotal());
    }
}
