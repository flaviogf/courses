package br.com.flaviogf.schedule.database;

import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.OnConflictStrategy;
import androidx.room.Query;

import java.util.List;

import br.com.flaviogf.schedule.models.Student;

@Dao
public interface StudentDao {
    @Insert(onConflict = OnConflictStrategy.REPLACE)
    void save(Student student);

    @Delete
    void remove(Student student);

    @Query("SELECT * FROM student")
    List<Student> findAll();

    @Query("SELECT * FROM student WHERE id = :id LIMIT 1")
    Student findOne(String id);
}
