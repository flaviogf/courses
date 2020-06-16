package br.com.flaviogf.schedule.viewmodels;

import androidx.annotation.NonNull;
import androidx.lifecycle.ViewModel;
import androidx.lifecycle.ViewModelProvider;

import br.com.flaviogf.schedule.repositories.StudentRepository;

public class StudentsViewModelFactory implements ViewModelProvider.Factory {
    private final StudentRepository studentRepository;

    public StudentsViewModelFactory(StudentRepository studentRepository) {
        this.studentRepository = studentRepository;
    }

    @NonNull
    @Override
    public <T extends ViewModel> T create(@NonNull Class<T> modelClass) {
        return (T) new StudentsViewModel(studentRepository);
    }
}
