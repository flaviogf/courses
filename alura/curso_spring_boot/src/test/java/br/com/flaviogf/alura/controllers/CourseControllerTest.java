package br.com.flaviogf.alura.controllers;

import br.com.flaviogf.alura.models.Course;
import br.com.flaviogf.alura.repository.CourseRepository;
import org.junit.Test;

import java.util.Collections;
import java.util.List;

import static org.junit.Assert.assertEquals;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class CourseControllerTest {

    @Test
    public void shouldListReturnCoursesList() {
        CourseRepository courseRepository = mock(CourseRepository.class);

        Course course = new Course(1, "Spring Boot", "Programming");

        List<Course> courses = Collections.singletonList(course);

        when(courseRepository.findAll()).thenReturn(courses);

        var courseController = new CourseController(courseRepository);

        var result = Collections.singletonList(courseController.list()).size();

        var expected = 1;

        assertEquals(expected, result);
    }

    @Test
    public void shouldFilterReturnCoursesList() {
        CourseRepository courseRepository = mock(CourseRepository.class);

        Course course = new Course(1, "Spring Boot", "Programming");

        List<Course> courses = Collections.singletonList(course);

        when(courseRepository.findByName("Spring Boot")).thenReturn(courses);

        var courseController = new CourseController(courseRepository);

        var result = Collections.singletonList(courseController.filter("Spring Boot")).size();

        var expected = 1;

        assertEquals(expected, result);
    }
}
