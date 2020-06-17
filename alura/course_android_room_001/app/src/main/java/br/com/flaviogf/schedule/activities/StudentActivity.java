package br.com.flaviogf.schedule.activities;

import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.lifecycle.ViewModelProvider;

import java.util.UUID;

import br.com.flaviogf.schedule.R;
import br.com.flaviogf.schedule.ScheduleApplication;
import br.com.flaviogf.schedule.infrastructure.Maybe;
import br.com.flaviogf.schedule.models.Student;
import br.com.flaviogf.schedule.viewmodels.StudentViewModel;
import br.com.flaviogf.schedule.viewmodels.StudentViewModelFactory;

public class StudentActivity extends AppCompatActivity {
    private StudentViewModel viewModel;
    private EditText idEditText;
    private EditText nameEditText;
    private EditText emailEditText;
    private EditText phoneEditText;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_student);

        idEditText = findViewById(R.id.activity_student_id_edit_text);
        nameEditText = findViewById(R.id.activity_student_name_edit_text);
        emailEditText = findViewById(R.id.activity_student_email_edit_text);
        phoneEditText = findViewById(R.id.activity_student_phone_edit_text);

        ScheduleApplication application = (ScheduleApplication) getApplication();

        StudentViewModelFactory factory = new StudentViewModelFactory(application.studentRepository());

        viewModel = new ViewModelProvider(this, factory).get(StudentViewModel.class);

        fillFields();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.activity_student_options_menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case R.id.activity_student_options_menu_done:
                saveStudent();
                break;
        }

        return super.onOptionsItemSelected(item);
    }

    private void fillFields() {
        String id = getIntent().getStringExtra("@student-id");

        if (id == null) {
            idEditText.setText(UUID.randomUUID().toString());
            return;
        }

        viewModel.fetchOne(id).observe(this, (result) -> {
            if (result.isFailure()) {
                idEditText.setText(UUID.randomUUID().toString());
                Toast.makeText(this, result.getMessage(), Toast.LENGTH_SHORT).show();
                return;
            }

            Student student = result.getValue();

            idEditText.setText(student.getId());
            nameEditText.setText(student.getName());
            emailEditText.setText(student.getEmail());
            phoneEditText.setText(student.getPhone());
        });
    }

    private void saveStudent() {
        Maybe<Student> maybeStudent = getStudent();

        if (!maybeStudent.hasValue()) {
            Toast.makeText(this, "Enter all data", Toast.LENGTH_SHORT).show();
            return;
        }

        Student student = maybeStudent.getValue();

        viewModel.save(student).observe(this, (result) -> {
            if (result.isFailure()) {
                Toast.makeText(this, result.getMessage(), Toast.LENGTH_SHORT).show();
                return;
            }

            finish();
        });
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

        Student student = new Student(id, name, email, phone);

        return Maybe.of(student);
    }
}
