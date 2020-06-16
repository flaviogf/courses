package br.com.flaviogf.schedule.adapters;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import br.com.flaviogf.schedule.R;
import br.com.flaviogf.schedule.models.Student;

public class StudentListAdapter extends BaseAdapter {
    private final Context context;
    private final List<Student> students = new ArrayList<>();

    public StudentListAdapter(Context context) {
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
        View layout = LayoutInflater.from(context).inflate(R.layout.item_student, viewGroup, false);

        TextView nameTextView = layout.findViewById(R.id.item_student_name_text_view);
        TextView phoneTextView = layout.findViewById(R.id.item_student_phone_text_view);

        Student student = students.get(position);

        nameTextView.setText(student.getName());
        phoneTextView.setText(student.getPhone());

        return layout;
    }

    public void update(List<Student> students) {
        this.students.clear();
        this.students.addAll(students);
        notifyDataSetChanged();
    }
}
