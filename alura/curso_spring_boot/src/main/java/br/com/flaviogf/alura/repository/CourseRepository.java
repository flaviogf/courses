package br.com.flaviogf.alura.repository;

import br.com.flaviogf.alura.models.Course;
import org.springframework.data.repository.CrudRepository;

public interface CourseRepository extends CrudRepository<Course, Long> {
    Iterable<Course> findByName(String name);
}
