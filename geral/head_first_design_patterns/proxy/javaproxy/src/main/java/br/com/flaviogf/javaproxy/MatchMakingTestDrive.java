package br.com.flaviogf.javaproxy;

import java.lang.reflect.Proxy;

public class MatchMakingTestDrive {
    public static void main(String[] args) {
        PersonBean joe = new PersonBeanImpl();

        joe.setName("Joe");
        joe.setHorOrNotRating(20);

        PersonBean owner = getOwner(joe);

        try {
            owner.setHorOrNotRating(10);
        } catch (Exception ex) {
            ex.printStackTrace();
        }

        PersonBean noOwner = getNoOwner(joe);

        try {
            noOwner.setName("Wrong");
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private static PersonBean getOwner(PersonBean person) {
        return (PersonBean) Proxy.newProxyInstance(person.getClass().getClassLoader(), person.getClass().getInterfaces(), new OwnerInvocationHandler(person));
    }

    private static PersonBean getNoOwner(PersonBean person) {
        return (PersonBean) Proxy.newProxyInstance(person.getClass().getClassLoader(), person.getClass().getInterfaces(), new NoOwnerInvocationHandler(person));
    }
}
