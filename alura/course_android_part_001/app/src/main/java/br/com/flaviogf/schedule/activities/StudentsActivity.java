package br.com.flaviogf.schedule.activities;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.util.List;

import br.com.flaviogf.schedule.R;
import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;
import br.com.flaviogf.schedule.services.FakeStudentService;
import br.com.flaviogf.schedule.services.StudentService;

public class StudentsActivity extends AppCompatActivity {
    private final StudentService studentService = new FakeStudentService();

    private FloatingActionButton studentsFloatingActionButton;
    private ListView studentsListView;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_students);
        setTitle("Students");

        studentsFloatingActionButton = findViewById(R.id.activity_students_floating_action_button);
        studentsListView = findViewById(R.id.activity_students_list_view);

        studentsFloatingActionButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(StudentsActivity.this, StudentActivity.class);
                startActivity(intent);
            }
        });
    }

    @Override
    protected void onResume() {
        super.onResume();

        Result<List<Student>> result = studentService.fetch();

        if (result.isFailure()) {
            Toast.makeText(this, result.getMessage(), Toast.LENGTH_SHORT).show();
            return;
        }

        List<Student> students = result.getValue();

        studentsListView.setAdapter(new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, students));
    }
}
