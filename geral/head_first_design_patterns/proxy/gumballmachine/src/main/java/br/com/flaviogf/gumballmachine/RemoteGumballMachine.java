package br.com.flaviogf.gumballmachine;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface RemoteGumballMachine extends Remote {
    Integer getCount() throws RemoteException;

    String getLocation() throws RemoteException;
}
