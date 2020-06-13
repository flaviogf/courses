package br.com.flaviogf.schedule.services;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;

public class FakeStudentService implements StudentService {
    private final static List<Student> students = new ArrayList<>();

    @Override
    public Result<Void> add(Student student) {
        students.add(student);

        return Result.ok();
    }

    @Override
    public List<Student> fetch() {
        return Collections.unmodifiableList(students);
    }
}
