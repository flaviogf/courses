package br.com.flaviogf.schedule.repositories;

import java.util.List;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;

public interface StudentRepository {
    Result<List<Student>> fetch();
}
