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
import androidx.lifecycle.ViewModelProvider;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.util.List;

import br.com.flaviogf.schedule.R;
import br.com.flaviogf.schedule.ScheduleApplication;
import br.com.flaviogf.schedule.adapters.StudentListAdapter;
import br.com.flaviogf.schedule.models.Student;
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

        listView.setOnItemClickListener((adapterView, view, position, id) -> {
            Student student = adapter.getItem(position);
            Intent intent = new Intent(this, StudentActivity.class);
            intent.putExtra("@student-id", student.getId());
            startActivity(intent);
        });

        ScheduleApplication application = (ScheduleApplication) getApplication();

        StudentsViewModelFactory factory = new StudentsViewModelFactory(application.studentRepository());

        viewModel = new ViewModelProvider(this, factory).get(StudentsViewModel.class);

        registerForContextMenu(listView);
    }

    @Override
    protected void onResume() {
        super.onResume();

        viewModel.fetch().observe(this, (result) -> {
            if (result.isFailure()) {
                return;
            }

            List<Student> students = result.getValue();

            adapter.update(students);
        });
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

                Student student = adapter.getItem(info.position);

                new AlertDialog.Builder(this)
                        .setTitle("Remove student")
                        .setMessage("Are you sure you want to remove this student?")
                        .setNegativeButton("Cancel", null)
                        .setPositiveButton("Confirm", ((dialogInterface, i) -> removeStudent(student))).show();

                break;
        }

        return super.onContextItemSelected(item);
    }

    private void removeStudent(Student student) {
        viewModel.remove(student).observe(this, (result) -> {
            if (result.isFailure()) {
                Toast.makeText(this, result.getMessage(), Toast.LENGTH_SHORT).show();
                return;
            }

            adapter.remove(student);
        });
    }
}
