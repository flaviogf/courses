package br.com.flaviogf.schedule;

import android.app.Application;

import java.util.UUID;

import br.com.flaviogf.schedule.models.Student;
import br.com.flaviogf.schedule.services.MemoryStudentService;
import br.com.flaviogf.schedule.services.StudentService;

public class ScheduleApplication extends Application {
    @Override
    public void onCreate() {
        super.onCreate();

        StudentService studentService = new MemoryStudentService();

        studentService.save(new Student(UUID.randomUUID(), "Frank", "frank@email.com", "(16) 99999-9999"));
        studentService.save(new Student(UUID.randomUUID(), "Rex", "rex@email.com", "(16) 88888-8888"));
    }
}
