package br.com.flaviogf;

public class BonusController {
    private double total;

    public double getTotal() {
        return total;
    }

    public void register(Employee... employees) {
        for (Employee employee : employees) {
            total += employee.getBonus();
        }
    }
}
