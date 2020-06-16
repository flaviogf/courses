package br.com.flaviogf.schedule.activities;

import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import br.com.flaviogf.schedule.R;

public class StudentActivity extends AppCompatActivity {
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
                finish();
                break;
        }

        return super.onOptionsItemSelected(item);
    }
}
