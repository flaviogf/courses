package br.com.flaviogf.schedule;

import android.app.Application;

import androidx.room.Room;

import br.com.flaviogf.schedule.database.ScheduleDatabase;
import br.com.flaviogf.schedule.database.StudentDao;
import br.com.flaviogf.schedule.repositories.DatabaseStudentRepository;
import br.com.flaviogf.schedule.repositories.StudentRepository;

public class ScheduleApplication extends Application {
    private ScheduleDatabase database;

    @Override
    public void onCreate() {
        super.onCreate();

        database = Room.databaseBuilder(this, ScheduleDatabase.class, "students.db")
                .allowMainThreadQueries()
                .build();
    }

    public StudentRepository studentRepository() {
        StudentDao studentDao = database.studentDao();

        return new DatabaseStudentRepository(studentDao);
    }
}
