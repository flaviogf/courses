package br.com.flaviogf.technews.viewmodels;

import androidx.annotation.NonNull;
import androidx.lifecycle.ViewModel;
import androidx.lifecycle.ViewModelProvider;

import br.com.flaviogf.technews.repositories.NewsRepository;

public class NewsListViewModelFactory implements ViewModelProvider.Factory {
    private final NewsRepository newsRepository;

    public NewsListViewModelFactory(NewsRepository newsRepository) {
        this.newsRepository = newsRepository;
    }

    @NonNull
    @Override
    public <T extends ViewModel> T create(@NonNull Class<T> modelClass) {
        return (T) new NewsListViewModel(newsRepository);
    }
}
