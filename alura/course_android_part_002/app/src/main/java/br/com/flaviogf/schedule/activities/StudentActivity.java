package br.com.flaviogf.schedule.activities;

import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import java.util.UUID;

import br.com.flaviogf.schedule.R;
import br.com.flaviogf.schedule.infrastructure.Maybe;
import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;
import br.com.flaviogf.schedule.services.MemoryStudentService;
import br.com.flaviogf.schedule.services.StudentService;

public class StudentActivity extends AppCompatActivity {
    private StudentService studentService = new MemoryStudentService();
    private EditText idEditText;
    private EditText nameEditText;
    private EditText emailEditText;
    private EditText phoneEditText;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_student);
        setTitle("Student");

        idEditText = findViewById(R.id.activity_student_id_edit_text);
        nameEditText = findViewById(R.id.activity_student_name_edit_text);
        emailEditText = findViewById(R.id.activity_student_email_edit_text);
        phoneEditText = findViewById(R.id.activity_student_phone_edit_text);

        fillFields();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.activity_student_menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case R.id.activity_student_menu_done:
                saveStudent();
                break;
        }

        return super.onOptionsItemSelected(item);
    }

    private void fillFields() {
        Maybe<UUID> maybeId = Maybe.of((UUID) getIntent().getSerializableExtra("@student-id"));

        if (!maybeId.hasValue()) {
            idEditText.setText(UUID.randomUUID().toString());
            return;
        }

        UUID id = maybeId.getValue();

        Result<Student> result = studentService.fetchOne(id);

        if (result.isFailure()) {
            Toast.makeText(this, result.getMessage(), Toast.LENGTH_SHORT).show();
            idEditText.setText(UUID.randomUUID().toString());
            return;
        }

        Student student = result.getValue();

        idEditText.setText(student.getId().toString());
        nameEditText.setText(student.getName());
        emailEditText.setText(student.getEmail());
        phoneEditText.setText(student.getPhone());
    }

    private void saveStudent() {
        Maybe<Student> maybeStudent = getStudent();

        if (!maybeStudent.hasValue()) {
            Toast.makeText(StudentActivity.this, "Enter all data", Toast.LENGTH_SHORT).show();
            return;
        }

        Student student = maybeStudent.getValue();

        studentService.save(student);

        finish();
    }

    private Maybe<Student> getStudent() {
        String id = idEditText.getText().toString();
        String name = nameEditText.getText().toString();
        String email = emailEditText.getText().toString();
        String phone = phoneEditText.getText().toString();

        if (id.isEmpty()) {
            return Maybe.empty();
        }

        if (name.isEmpty()) {
            return Maybe.empty();
        }

        if (email.isEmpty()) {
            return Maybe.empty();
        }

        if (phone.isEmpty()) {
            return Maybe.empty();
        }

        Student student = new Student(UUID.fromString(id), name, email, phone);

        return Maybe.of(student);
    }
}
