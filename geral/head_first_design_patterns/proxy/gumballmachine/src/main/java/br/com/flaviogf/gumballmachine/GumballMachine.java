package br.com.flaviogf.gumballmachine;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class GumballMachine extends UnicastRemoteObject implements RemoteGumballMachine {
    private final String location;
    private final Integer count;

    public GumballMachine(String location, Integer count) throws RemoteException {
        this.location = location;
        this.count = count;
    }

    @Override
    public String getLocation() {
        return location;
    }

    @Override
    public Integer getCount() {
        return count;
    }
}
