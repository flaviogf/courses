package br.com.flaviogf.alura.controllers;

import br.com.flaviogf.alura.models.Course;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.Arrays;
import java.util.List;

@RestController
@RequestMapping("/courses")
public class CourseController {

    @GetMapping
    public List<Course> list() {
        return Arrays.asList(new Course(1, "Spring", "Programming"));
    }
}
