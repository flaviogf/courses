package br.com.flaviogf.technews.viewmodels;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import java.util.UUID;

import br.com.flaviogf.technews.infrastructure.Result;
import br.com.flaviogf.technews.models.News;
import br.com.flaviogf.technews.service.NewsService;

public class TechViewModel extends ViewModel {
    private final NewsService newsService;

    public TechViewModel(NewsService newsService) {
        this.newsService = newsService;
    }

    public LiveData<Result<News>> fetchOne(UUID id) {
        MutableLiveData<Result<News>> liveData = new MutableLiveData<>();

        Result<News> result = newsService.fetchOne(id);

        liveData.setValue(result);

        return liveData;
    }

    public LiveData<Result<Void>> save(News news) {
        MutableLiveData<Result<Void>> liveData = new MutableLiveData<>();

        Result<Void> result = newsService.save(news);

        liveData.setValue(result);

        return liveData;
    }
}
