package br.com.flaviogf.schedule.services;

import java.util.Collection;
import java.util.UUID;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;

public interface StudentService {
    Result<Void> save(Student student);

    Result<Void> remove(Student student);

    Result<Collection<Student>> fetch();

    Result<Student> fetchOne(UUID id);
}
