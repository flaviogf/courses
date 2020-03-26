package br.com.flaviogf.example56;

import java.time.Duration;
import java.time.Instant;
import java.time.LocalDate;
import java.time.LocalTime;
import java.time.Month;
import java.time.Period;

public class App {
    public static void main(String[] args) throws InterruptedException {
        Instant begin = Instant.now();
        Thread.sleep(1000);
        Instant end = Instant.now();
        System.out.println(Duration.between(begin, end).toMillis());

        LocalDate today = LocalDate.now();
        System.out.println(today);

        LocalDate birthday = LocalDate.of(2020, 6, 13);
        System.out.println(birthday);

        LocalDate manInSpace = LocalDate.of(1961, Month.APRIL, 12);
        LocalDate manInMoon = LocalDate.of(1969, Month.MAY, 25);

        Period period = Period.between(manInSpace, manInMoon);

        System.out.println(String.format("%d years, %d months and %d days", period.getYears(), period.getMonths(),
                period.getDays()));

        LocalTime startHour = LocalTime.of(9, 0);

        System.out.println(startHour);

        ZoneId.of("America/Sao_Paulo");
    }
}
