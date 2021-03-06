package br.com.flaviogf.schedule.repositories;

import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;

public class MemoryStudentRepository implements StudentRepository {
    private final static Map<String, Student> students = new HashMap<>();

    @Override
    public Result<Void> save(Student student) {
        students.put(student.getId(), student);

        return Result.ok();
    }

    @Override
    public Result<Void> remove(Student student) {
        students.remove(student.getId());

        return Result.ok();
    }

    @Override
    public Result<Collection<Student>> fetch() {
        Collection<Student> unmodifiableList = Collections.unmodifiableCollection(students.values());

        return Result.ok(unmodifiableList);
    }

    @Override
    public Result<Student> fetchOne(String id) {
        if (!students.containsKey(id)) {
            return Result.fail("Student does not exist");
        }

        Student student = students.get(id);

        return Result.ok(student);
    }
}
