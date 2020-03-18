package br.com.flaviogf;

public class VideoEditor extends Employee {
    public VideoEditor(String name, String document, double salary) {
        super(name, document, salary);
    }

    @Override
    public double getBonus() {
        return super.getBonus() + 100;
    }
}
