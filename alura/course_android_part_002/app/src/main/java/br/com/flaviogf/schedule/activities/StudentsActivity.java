package br.com.flaviogf.schedule.activities;

import android.content.Intent;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

import br.com.flaviogf.schedule.R;
import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;
import br.com.flaviogf.schedule.services.MemoryStudentService;
import br.com.flaviogf.schedule.services.StudentService;

public class StudentsActivity extends AppCompatActivity {
    private final StudentService studentService = new MemoryStudentService();
    private ArrayAdapter<Student> studentsArrayAdapter;
    private FloatingActionButton floatingActionButton;
    private ListView listView;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_students);
        setTitle("Students");

        studentsArrayAdapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1);
        floatingActionButton = findViewById(R.id.activity_students_floating_action_button);
        listView = findViewById(R.id.activity_students_list_view);

        floatingActionButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(StudentsActivity.this, StudentActivity.class);
                startActivity(intent);
            }
        });

        listView.setAdapter(studentsArrayAdapter);

        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int position, long id) {
                Student student = (Student) listView.getItemAtPosition(position);
                Intent intent = new Intent(StudentsActivity.this, StudentActivity.class);
                intent.putExtra("@student-id", student.getId());
                startActivity(intent);
            }
        });

        registerForContextMenu(listView);
    }

    @Override
    protected void onResume() {
        super.onResume();
        fetchStudents();
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        getMenuInflater().inflate(R.menu.activity_students_menu, menu);
    }

    @Override
    public boolean onContextItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case R.id.activity_students_menu_remove:
                AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
                Student student = studentsArrayAdapter.getItem(info.position);
                removeStudent(student);
                break;
        }

        return super.onContextItemSelected(item);
    }

    private void fetchStudents() {
        Result<Collection<Student>> result = studentService.fetch();

        if (result.isFailure()) {
            Toast.makeText(this, result.getMessage(), Toast.LENGTH_SHORT).show();
            return;
        }

        List<Student> students = new ArrayList<>(result.getValue());

        Collections.sort(students, new Comparator<Student>() {
            @Override
            public int compare(Student first, Student second) {
                return first.getName().compareTo(second.getName());
            }
        });

        studentsArrayAdapter.clear();

        studentsArrayAdapter.addAll(students);
    }

    private void removeStudent(Student student) {
        Result<Void> result = studentService.remove(student);

        if (result.isFailure()) {
            Toast.makeText(this, result.getMessage(), Toast.LENGTH_SHORT).show();
            return;
        }

        studentsArrayAdapter.remove(student);
    }
}
