package br.com.flaviogf.schedule.services;

import java.util.Arrays;
import java.util.Collection;
import java.util.Collections;
import java.util.HashSet;
import java.util.Set;
import java.util.UUID;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;

public class MemoryStudentService implements StudentService {
    private final static Set<Student> students = new HashSet<>(Arrays.asList(
            new Student(UUID.randomUUID(), "Frank", "frank@email.com", "16999999999"),
            new Student(UUID.randomUUID(), "Rex", "rex@email.com", "16999999999")
    ));

    @Override
    public Result<Void> save(Student student) {
        students.add(student);

        return Result.ok();
    }

    @Override
    public Result<Void> remove(Student student) {
        students.remove(student);

        return Result.ok();
    }

    @Override
    public Result<Collection<Student>> fetch() {
        Collection<Student> unmodifiableStudents = Collections.unmodifiableSet(MemoryStudentService.students);

        return Result.ok(unmodifiableStudents);
    }
}
