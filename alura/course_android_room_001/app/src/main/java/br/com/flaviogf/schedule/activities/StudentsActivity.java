package br.com.flaviogf.schedule.activities;

import android.content.Intent;
import android.os.Bundle;
import android.widget.ListView;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.lifecycle.ViewModelProvider;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.util.List;

import br.com.flaviogf.schedule.R;
import br.com.flaviogf.schedule.adapters.StudentListAdapter;
import br.com.flaviogf.schedule.models.Student;
import br.com.flaviogf.schedule.repositories.MemoryStudentRepository;
import br.com.flaviogf.schedule.repositories.StudentRepository;
import br.com.flaviogf.schedule.viewmodels.StudentsViewModel;
import br.com.flaviogf.schedule.viewmodels.StudentsViewModelFactory;

public class StudentsActivity extends AppCompatActivity {
    private StudentsViewModel viewModel;
    private StudentListAdapter adapter;
    private FloatingActionButton floatingActionButton;
    private ListView listView;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_students);

        adapter = new StudentListAdapter(this);

        floatingActionButton = findViewById(R.id.activity_students_floating_action_button);

        listView = findViewById(R.id.activity_students_list_view);

        floatingActionButton.setOnClickListener((view) -> {
            Intent intent = new Intent(this, StudentActivity.class);
            startActivity(intent);
        });

        listView.setAdapter(adapter);

        StudentRepository studentRepository = new MemoryStudentRepository();

        StudentsViewModelFactory factory = new StudentsViewModelFactory(studentRepository);

        viewModel = new ViewModelProvider(this, factory).get(StudentsViewModel.class);

        viewModel.fetch().observe(this, (result) -> {
            if (result.isFailure()) {
                return;
            }

            List<Student> students = result.getValue();

            adapter.update(students);
        });
    }
}
