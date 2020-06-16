package br.com.flaviogf.schedule.viewmodels;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import java.util.List;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;
import br.com.flaviogf.schedule.repositories.StudentRepository;

public class StudentsViewModel extends ViewModel {
    private final StudentRepository studentRepository;

    public StudentsViewModel(StudentRepository studentRepository) {
        this.studentRepository = studentRepository;
    }

    public LiveData<Result<List<Student>>> fetch() {
        MutableLiveData<Result<List<Student>>> liveData = new MutableLiveData<>();

        Result<List<Student>> result = studentRepository.fetch();

        liveData.setValue(result);

        return liveData;
    }
}
