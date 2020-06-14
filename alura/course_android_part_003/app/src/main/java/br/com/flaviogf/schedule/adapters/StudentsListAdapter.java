package br.com.flaviogf.schedule.adapters;

import android.annotation.SuppressLint;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.UUID;

import br.com.flaviogf.schedule.R;
import br.com.flaviogf.schedule.models.Student;

public class StudentsListAdapter extends BaseAdapter {
    private final Context context;
    private final List<Student> students = new ArrayList<>(Collections.singletonList(
            new Student(UUID.randomUUID(), "Frank", "frank@email.com", "(16) 99999-9999")
    ));

    public StudentsListAdapter(Context context) {
        this.context = context;
    }

    @Override
    public int getCount() {
        return students.size();
    }

    @Override
    public Student getItem(int position) {
        return students.get(position);
    }

    @Override
    public long getItemId(int position) {
        return 0;
    }

    @Override
    public View getView(int position, View view, ViewGroup viewGroup) {
        @SuppressLint("ViewHolder") View itemView = LayoutInflater.from(context).inflate(R.layout.item_student, viewGroup, false);

        Student student = students.get(position);

        TextView nameTextView = itemView.findViewById(R.id.item_student_name_text_view);
        TextView phoneTextView = itemView.findViewById(R.id.item_student_phone_text_view);

        nameTextView.setText(student.getName());
        phoneTextView.setText(student.getPhone());

        return itemView;
    }

    public void remove(Student student) {
        students.remove(student);
        notifyDataSetChanged();
    }

    public void update(List<Student> students) {
        this.students.clear();
        this.students.addAll(students);
    }
}
