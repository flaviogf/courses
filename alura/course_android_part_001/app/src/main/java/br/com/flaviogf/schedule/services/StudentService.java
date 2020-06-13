package br.com.flaviogf.schedule.services;

import java.util.List;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;

public interface StudentService {
    Result<Void> add(Student student);

    List<Student> fetch();
}
