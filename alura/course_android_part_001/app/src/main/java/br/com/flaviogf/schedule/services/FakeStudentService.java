package br.com.flaviogf.schedule.services;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;

public class FakeStudentService implements StudentService {
    private final static List<Student> students = new ArrayList<>();

    @Override
    public Result<Void> create(Student student) {
        students.add(student);

        return Result.ok();
    }

    @Override
    public Result<List<Student>> fetch() {
        List<Student> unmodifiableStudents = Collections.unmodifiableList(students);

        return Result.ok(unmodifiableStudents);
    }
}
