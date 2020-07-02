package br.com.flaviogf.javaproxy;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;

public class OwnerInvocationHandler implements InvocationHandler {
    private final PersonBean person;

    public OwnerInvocationHandler(PersonBean person) {
        this.person = person;
    }

    @Override
    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
        if (method.getName().equals("setHorOrNotRating")) {
            throw new IllegalAccessException("You cannot rating yourself");
        }

        if (method.getName().startsWith("get") || method.getName().startsWith("set")) {
            return method.invoke(person, args);
        }

        return null;
    }
}
