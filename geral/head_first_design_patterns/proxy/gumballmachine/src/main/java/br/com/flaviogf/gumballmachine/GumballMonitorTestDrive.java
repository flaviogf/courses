package br.com.flaviogf.gumballmachine;

import java.rmi.Naming;

public class GumballMonitorTestDrive {
    public static void main(String[] args) {
        try {
            RemoteGumballMachine machine = (RemoteGumballMachine) Naming.lookup("rmi://localhost/GumballMachine");

            GumballMonitor monitor = new GumballMonitor(machine);

            monitor.report();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
