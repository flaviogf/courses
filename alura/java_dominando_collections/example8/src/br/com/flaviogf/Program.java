package br.com.flaviogf;

public class Program {

    public static void main(String[] args) {
        Course javaCollections = new Course("Java Collections", "Paulo");

        javaCollections.register(new Student("Frank", 1));
        javaCollections.register(new Student("Nina", 2));

        boolean isFrankRegistered = javaCollections.isRegistered(new Student("Frank", 1));

        System.out.println(String.format("Is Frank registered in the Java Collections Course? %b", isFrankRegistered));

        boolean isRexRegistered = javaCollections.isRegistered(new Student("Rex", 3));

        System.out.println(String.format("Is Rex registered in the Java Collections Course? %b", isRexRegistered));
    }
}
