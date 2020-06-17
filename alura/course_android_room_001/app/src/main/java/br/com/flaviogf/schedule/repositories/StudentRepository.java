package br.com.flaviogf.schedule.repositories;

import java.util.Collection;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;

public interface StudentRepository {
    Result<Void> save(Student student);

    Result<Void> remove(Student student);

    Result<Collection<Student>> fetch();

    Result<Student> fetchOne(String id);
}
