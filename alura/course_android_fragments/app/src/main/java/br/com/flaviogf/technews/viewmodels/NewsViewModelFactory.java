package br.com.flaviogf.technews.viewmodels;

import androidx.annotation.NonNull;
import androidx.lifecycle.ViewModel;
import androidx.lifecycle.ViewModelProvider;

import br.com.flaviogf.technews.repositories.NewsRepository;

public class NewsViewModelFactory implements ViewModelProvider.Factory {
    private final NewsRepository newsRepository;

    public NewsViewModelFactory(NewsRepository newsRepository) {
        this.newsRepository = newsRepository;
    }

    @NonNull
    @Override
    public <T extends ViewModel> T create(@NonNull Class<T> modelClass) {
        return (T) new NewsViewModel(newsRepository);
    }
}
