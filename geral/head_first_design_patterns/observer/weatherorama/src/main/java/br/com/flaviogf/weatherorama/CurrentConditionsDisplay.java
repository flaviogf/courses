package br.com.flaviogf.weatherorama;

public class CurrentConditionsDisplay implements Observer, Display {
    private Subject weatherData;
    private float temperature;
    private float humidity;

    public CurrentConditionsDisplay(Subject weatherData) {
        this.weatherData = weatherData;
        weatherData.register(this);
    }

    @Override
    public void update(float temperature, float humidity, float pressure) {
        this.temperature = temperature;
        this.humidity = humidity;
        display();
    }

    @Override
    public void display() {
        System.out.println(String.format("Current Conditions -> Temperature: %.2f, Humidity: %.2f", temperature, humidity));
    }
}
