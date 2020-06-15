package br.com.flaviogf.technews.viewmodels;

import androidx.annotation.NonNull;
import androidx.lifecycle.ViewModel;
import androidx.lifecycle.ViewModelProvider;

import br.com.flaviogf.technews.service.NewsService;

public class TechsViewModelFactory implements ViewModelProvider.Factory {
    private final NewsService newsService;

    public TechsViewModelFactory(NewsService newsService) {
        this.newsService = newsService;
    }

    @NonNull
    @Override
    public <T extends ViewModel> T create(@NonNull Class<T> modelClass) {
        return (T) new TechsViewModel(newsService);
    }
}
