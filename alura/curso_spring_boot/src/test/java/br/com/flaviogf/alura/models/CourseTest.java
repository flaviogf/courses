package br.com.flaviogf.alura.models;

import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class CourseTest {

    @Test
    public void shouldReturnStringRepresentation() {
        var course = new Course(1, "Spring Boot", "Programming");

        var result = course.toString();

        var expected = "Course(name='Spring Boot')";

        assertEquals(expected, result);
    }
}
