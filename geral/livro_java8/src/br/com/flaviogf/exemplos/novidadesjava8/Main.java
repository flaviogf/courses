package br.com.flaviogf.exemplos.novidadesjava8;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.Month;
import java.time.Period;
import java.time.format.DateTimeFormatter;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class Main {

    private static void exemplosData() {
        LocalDate aniversario = LocalDate.of(2018, Month.JUNE, 13);
        LocalDate hoje = LocalDate.now();
        System.out.println(Period.between(hoje, aniversario));
        LocalDate proximo = aniversario.plusYears(1);
        System.out.println(Period.between(hoje, proximo));

        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd/MM/yyyy");
        String format = formatter.format(hoje);
        DateTimeFormatter formatter2 = DateTimeFormatter.ofPattern("dd/MM/yyyy HH:mm");
        System.out.println(format);
        LocalDateTime now = LocalDateTime.now();
        System.out.println(now.format(formatter2));
    }

    private static void exemplosStream() {
        List<Curso> cursos = Arrays.asList(
                new Curso("Javascript", 150),
                new Curso("C#", 150),
                new Curso("Java", 300)
        );

        int soma = cursos.stream()
                .filter(curso -> curso.getAlunos() >= 100)
                .mapToInt(Curso::getAlunos)
                .sum();

        List<Curso> coletados = cursos.stream()
                .filter(curso -> curso.getNome().toLowerCase().startsWith("java"))
                .collect(Collectors.toList());

        cursos.stream()
                .filter(curso -> curso.getAlunos() > 100)
                .findAny()
                .ifPresent(System.out::println);

        cursos.stream()
                .mapToInt(Curso::getAlunos)
                .average()
                .ifPresent(System.out::println);

        System.out.println("Total alunos em cursos com mais de 100 matrículas: " + soma);

        System.out.println(coletados);
    }

    public static void main(String[] args) {
        exemplosStream();
        exemplosData();
    }
}
