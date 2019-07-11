package br.com.flaviogf.alura.controllers;

import br.com.flaviogf.alura.models.Course;
import br.com.flaviogf.alura.repository.CourseRepository;
import org.junit.Before;
import org.junit.Test;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageImpl;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.util.UriComponentsBuilder;

import java.util.Collections;
import java.util.List;
import java.util.Optional;

import static java.util.Optional.empty;
import static org.junit.Assert.assertEquals;
import static org.mockito.Matchers.any;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class CourseControllerTest {

    private CourseRepository courseRepository;

    private CourseController courseController;

    @Before
    public void setUp() {
        courseRepository = mock(CourseRepository.class);
        courseController = new CourseController(courseRepository);
    }


    @Test
    public void shouldCreateCourseReturnStatusCodeOk() {
        UriComponentsBuilder builder = UriComponentsBuilder.newInstance();

        var course = new Course(1, "JavaScript", "Front-End");

        when(courseRepository.save(course)).thenReturn(course);

        ResponseEntity<Course> response = courseController.create(course, builder);

        assertEquals(HttpStatus.CREATED, response.getStatusCode());
    }

    @Test
    public void shouldAllReturnCoursesList() {
        Course course = new Course(1, "Spring Boot", "Programming");

        List<Course> courses = Collections.singletonList(course);

        when(courseRepository.findAll()).thenReturn(courses);

        int result = Collections.singletonList(courseController.all().getBody()).size();

        var expected = 1;

        assertEquals(expected, result);
    }

    @Test
    public void shouldFilterReturnCoursesList() {
        Course course = new Course(1, "Spring Boot", "Programming");

        List<Course> courses = Collections.singletonList(course);

        when(courseRepository.findByName("Spring Boot")).thenReturn(courses);

        int result = Collections.singletonList(courseController.filter("Spring Boot").getBody()).size();

        var expected = 1;

        assertEquals(expected, result);
    }

    @Test
    public void shouldFindByIdReturnCourseWhenExists() {
        long id = 1;

        Course expected = new Course(1, "Spring Boot", "Programming");

        when(courseRepository.findById(id)).thenReturn(Optional.of(expected));

        ResponseEntity<Course> response = courseController.findById(id);

        Course result = response.getBody();

        assertEquals(expected.getId(), result.getId());
    }

    @Test
    public void shouldFindByIdReturnNotFoundWhenNotExists() {
        long id = 1;

        when(courseRepository.findById(id)).thenReturn(empty());

        var response = courseController.findById(id);

        var result = response.getStatusCode();

        var expected = HttpStatus.NOT_FOUND;

        assertEquals(expected, result);
    }

    @Test
    public void shouldPaginatedReturnCoursesList() {
        Course course = new Course(1, "Spring Boot", "Programming");

        List<Course> courses = Collections.singletonList(course);

        PageImpl<Course> page = new PageImpl<>(courses);

        when(courseRepository.findAll(any())).thenReturn(page);

        Pageable pageable = PageRequest.of(1, 2);

        ResponseEntity<Page<Course>> response = courseController.paginated(pageable);

        long result = response.getBody().getTotalElements();

        long expected = 1;

        assertEquals(expected, result);
    }
}
