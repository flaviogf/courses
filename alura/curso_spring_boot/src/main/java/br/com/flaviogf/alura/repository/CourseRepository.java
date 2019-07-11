package br.com.flaviogf.alura.repository;

import br.com.flaviogf.alura.models.Course;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.repository.CrudRepository;

public interface CourseRepository extends CrudRepository<Course, Long> {
    Page<Course> findAll(Pageable pageable);

    Iterable<Course> findByName(String name);
}
