package br.com.flaviogf.javaproxy;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;

public class NoOwnerInvocationHandler implements InvocationHandler {
    private final PersonBean person;

    public NoOwnerInvocationHandler(PersonBean person) {
        this.person = person;
    }

    @Override
    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
        if (method.getName().equals("setHorOrNotRating") || method.getName().startsWith("get")) {
            return method.invoke(person, args);
        }

        if (method.getName().startsWith("set")) {
            throw new IllegalAccessException("You cannot update information that are not yours");
        }

        return null;
    }
}
