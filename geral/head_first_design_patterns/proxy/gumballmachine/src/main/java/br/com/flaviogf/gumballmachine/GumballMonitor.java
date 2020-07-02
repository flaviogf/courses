package br.com.flaviogf.gumballmachine;

import java.rmi.RemoteException;

public class GumballMonitor {
    private final RemoteGumballMachine machine;

    public GumballMonitor(RemoteGumballMachine machine) {
        this.machine = machine;
    }

    public void report() {
        try {
            System.out.println(String.format("Gumball machine %s", machine.getLocation()));
            System.out.println(String.format("Current inventory %d", machine.getCount()));
        } catch (RemoteException e) {
            e.printStackTrace();
        }
    }
}
