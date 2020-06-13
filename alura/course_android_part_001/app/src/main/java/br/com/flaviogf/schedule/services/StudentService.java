package br.com.flaviogf.schedule.services;

import java.util.List;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;

public interface StudentService {
    Result<Void> create(Student student);

    Result<List<Student>> fetch();
}
