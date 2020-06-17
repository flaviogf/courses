package br.com.flaviogf.schedule.viewmodels;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import br.com.flaviogf.schedule.infrastructure.Result;
import br.com.flaviogf.schedule.models.Student;
import br.com.flaviogf.schedule.repositories.StudentRepository;

public class StudentViewModel extends ViewModel {
    private final StudentRepository studentRepository;

    public StudentViewModel(StudentRepository studentRepository) {
        this.studentRepository = studentRepository;
    }

    public LiveData<Result<Student>> fetchOne(String id) {
        MutableLiveData<Result<Student>> liveData = new MutableLiveData<>();

        Result<Student> result = studentRepository.fetchOne(id);

        liveData.setValue(result);

        return liveData;
    }

    public LiveData<Result<Void>> save(Student student) {
        MutableLiveData<Result<Void>> liveData = new MutableLiveData<>();

        Result<Void> result = studentRepository.save(student);

        liveData.setValue(result);

        return liveData;
    }
}
