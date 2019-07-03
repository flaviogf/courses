package br.com.flaviogf.alura.controllers;

import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class CourseControllerTest {

    @Test
    public void shouldListReturnCoursesList() {
        var courseController = new CourseController();

        var result = courseController.list().size();

        var expected = 1;

        assertEquals(expected, result);
    }
}
