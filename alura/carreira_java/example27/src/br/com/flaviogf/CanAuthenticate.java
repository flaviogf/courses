package br.com.flaviogf;

public interface CanAuthenticate {
    void setPassword(String password);

    boolean authenticate(String password);
}
