package br.com.flaviogf.schedule.repositories;

import java.util.Arrays;
import java.util.List;
import java.util.UUID;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;

public class MemoryStudentRepository implements StudentRepository {
    @Override
    public Result<List<Student>> fetch() {
        return Result.ok(Arrays.asList(
                new Student(UUID.randomUUID().toString(), "Frank", "frank@email.com", "16999999999"),
                new Student(UUID.randomUUID().toString(), "Nina", "nina@email.com", "16888888888")
        ));
    }
}
