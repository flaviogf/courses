package br.com.flaviogf.gumballmachine;

import java.rmi.Naming;

public class GumballMachineTestDrive {
    public static void main(String[] args) {
        try {
            GumballMachine machine = new GumballMachine("localhost", 15);

            Naming.rebind("//localhost/GumballMachine", machine);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
