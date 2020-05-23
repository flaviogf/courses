package br.com.flaviogf.weatherorama;

public interface Observer {
    void update(float temperature, float humidity, float pressure);
}
