package br.com.flaviogf.schedule.repositories;

import java.util.Collection;
import java.util.List;

import br.com.flaviogf.schedule.database.StudentDao;
import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;

public class DatabaseStudentRepository implements StudentRepository {
    private final StudentDao studentDao;

    public DatabaseStudentRepository(StudentDao studentDao) {
        this.studentDao = studentDao;
    }

    @Override
    public Result<Void> save(Student student) {
        studentDao.save(student);

        return Result.ok();
    }

    @Override
    public Result<Void> remove(Student student) {
        studentDao.remove(student);

        return Result.ok();
    }

    @Override
    public Result<Collection<Student>> fetch() {
        List<Student> students = studentDao.findAll();

        return Result.ok(students);
    }

    @Override
    public Result<Student> fetchOne(String id) {
        Student student = studentDao.findOne(id);

        if (student == null) {
            return Result.fail("Student does not exist");
        }

        return Result.ok(student);
    }
}
