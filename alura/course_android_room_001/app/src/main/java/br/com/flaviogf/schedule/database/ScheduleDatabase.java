package br.com.flaviogf.schedule.database;

import androidx.room.Database;
import androidx.room.RoomDatabase;

import br.com.flaviogf.schedule.models.Student;

@Database(entities = {Student.class}, version = 1, exportSchema = false)
public abstract class ScheduleDatabase extends RoomDatabase {
    public abstract StudentDao studentDao();
}
