package br.com.flaviogf.schedule.activities;

import android.content.Intent;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;

import br.com.flaviogf.schedule.R;
import br.com.flaviogf.schedule.adapters.StudentsListAdapter;
import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;
import br.com.flaviogf.schedule.services.MemoryStudentService;
import br.com.flaviogf.schedule.services.StudentService;

public class StudentsActivity extends AppCompatActivity {
    private final StudentService studentService = new MemoryStudentService();
    private StudentsListAdapter studentsListAdapter;
    private FloatingActionButton floatingActionButton;
    private ListView listView;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_students);
        setTitle("Students");

        studentsListAdapter = new StudentsListAdapter(this);

        floatingActionButton = findViewById(R.id.activity_students_floating_action_button);
        listView = findViewById(R.id.activity_students_list_view);

        floatingActionButton.setOnClickListener(view -> {
            Intent intent = new Intent(this, StudentActivity.class);
            startActivity(intent);
        });

        listView.setAdapter(studentsListAdapter);

        listView.setOnItemClickListener((adapterView, view, position, id) -> {
            Intent intent = new Intent(this, StudentActivity.class);
            Student student = studentsListAdapter.getItem(position);
            intent.putExtra("@student-id", student.getId());
            startActivity(intent);
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
        getMenuInflater().inflate(R.menu.activity_students_context_menu, menu);
    }

    @Override
    public boolean onContextItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case R.id.activity_students_context_menu_remove:
                AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();

                Student student = studentsListAdapter.getItem(info.position);

                AlertDialog.Builder alert = new AlertDialog.Builder(this)
                        .setTitle("Remove student")
                        .setMessage("Are you sure you want to remove the student?")
                        .setNegativeButton("Cancel", null)
                        .setPositiveButton("Confirm", ((dialogInterface, i) -> removeStudent(student)));

                alert.show();

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

        ArrayList<Student> students = new ArrayList<>(result.getValue());

        Collections.sort(students, (first, second) -> first.getName().compareTo(second.getName()));

        studentsListAdapter.update(students);
    }

    private void removeStudent(Student student) {
        studentsListAdapter.remove(student);
    }
}
