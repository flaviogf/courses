package br.com.flaviogf.alura.controllers;

import br.com.flaviogf.alura.models.Course;
import br.com.flaviogf.alura.repository.CourseRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/courses")
public class CourseController {

    private CourseRepository courseRepository;

    @Autowired
    public CourseController(CourseRepository courseRepository) {
        this.courseRepository = courseRepository;
    }

    @GetMapping
    public Iterable<Course> list() {
        return courseRepository.findAll();
    }

    @GetMapping("/filter")
    public Iterable<Course> filter(String name) {
        return courseRepository.findByName(name);
    }
}
