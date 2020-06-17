package br.com.flaviogf.schedule.viewmodels;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;
import br.com.flaviogf.schedule.repositories.StudentRepository;

public class StudentsViewModel extends ViewModel {
    private final StudentRepository studentRepository;

    public StudentsViewModel(StudentRepository studentRepository) {
        this.studentRepository = studentRepository;
    }

    public LiveData<Result<Void>> remove(Student student) {
        MutableLiveData<Result<Void>> liveData = new MutableLiveData<>();

        Result<Void> result = studentRepository.remove(student);

        liveData.setValue(result);

        return liveData;
    }

    public LiveData<Result<List<Student>>> fetch() {
        MutableLiveData<Result<List<Student>>> liveData = new MutableLiveData<>();

        Result<Collection<Student>> result = studentRepository.fetch();

        List<Student> students = new ArrayList<>(result.getValue());

        Collections.sort(students, (first, second) -> first.getName().compareToIgnoreCase(second.getName()));

        liveData.setValue(Result.ok(students));

        return liveData;
    }
}
