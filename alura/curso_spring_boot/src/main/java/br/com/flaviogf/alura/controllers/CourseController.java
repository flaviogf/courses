package br.com.flaviogf.alura.controllers;

import br.com.flaviogf.alura.models.Course;
import br.com.flaviogf.alura.repository.CourseRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.util.UriComponentsBuilder;

import javax.validation.Valid;
import java.net.URI;
import java.util.Optional;

@RestController
@RequestMapping("/courses")
public class CourseController {

    private CourseRepository courseRepository;

    @Autowired
    public CourseController(CourseRepository courseRepository) {
        this.courseRepository = courseRepository;
    }

    @PostMapping
    public ResponseEntity<Course> create(@RequestBody @Valid Course course, UriComponentsBuilder builder) {
        var created = courseRepository.save(course);

        URI uri = builder.path("/courses/{id}").buildAndExpand(created.getId()).toUri();

        return ResponseEntity.created(uri).body(created);
    }

    @GetMapping
    public ResponseEntity<Iterable<Course>> all() {
        var courses = courseRepository.findAll();
        return ResponseEntity.ok(courses);
    }

    @GetMapping("/filter")
    public ResponseEntity<Iterable<Course>> filter(String name) {
        var courses = courseRepository.findByName(name);
        return ResponseEntity.ok(courses);
    }

    @GetMapping("/{id}")
    public ResponseEntity<Course> findById(@PathVariable long id) {
        Optional<Course> course = courseRepository.findById(id);

        if (course.isEmpty()) {
            return ResponseEntity.notFound().build();
        }

        return ResponseEntity.ok(course.get());
    }

    @GetMapping("paginated")
    public ResponseEntity<Page<Course>> paginated(Pageable pageable) {
        var page = courseRepository.findAll(pageable);
        return ResponseEntity.ok(page);
    }
}
