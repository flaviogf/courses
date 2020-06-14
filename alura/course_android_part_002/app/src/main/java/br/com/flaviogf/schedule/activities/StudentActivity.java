package br.com.flaviogf.schedule.activities;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import java.util.UUID;

import br.com.flaviogf.schedule.R;
import br.com.flaviogf.schedule.infrastructure.Maybe;
import br.com.flaviogf.schedule.models.Student;
import br.com.flaviogf.schedule.services.MemoryStudentService;
import br.com.flaviogf.schedule.services.StudentService;

public class StudentActivity extends AppCompatActivity {
    private StudentService studentService = new MemoryStudentService();
    private EditText nameEditText;
    private EditText emailEditText;
    private EditText phoneEditText;
    private Button saveButton;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_student);
        setTitle("Student");

        nameEditText = findViewById(R.id.activity_student_name_edit_text);
        emailEditText = findViewById(R.id.activity_student_email_edit_text);
        phoneEditText = findViewById(R.id.activity_student_phone_edit_text);
        saveButton = findViewById(R.id.activity_student_save_button);

        saveButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                saveStudent();
            }
        });
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
        String name = nameEditText.getText().toString();
        String email = emailEditText.getText().toString();
        String phone = phoneEditText.getText().toString();

        if (name.isEmpty()) {
            return Maybe.empty();
        }

        if (email.isEmpty()) {
            return Maybe.empty();
        }

        if (phone.isEmpty()) {
            return Maybe.empty();
        }

        Student student = new Student(UUID.randomUUID(), name, email, phone);

        return Maybe.of(student);
    }
}
