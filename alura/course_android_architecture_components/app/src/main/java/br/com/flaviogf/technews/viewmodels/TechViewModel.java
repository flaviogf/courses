package br.com.flaviogf.technews.viewmodels;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import br.com.flaviogf.technews.infrastructure.Result;
import br.com.flaviogf.technews.models.News;
import br.com.flaviogf.technews.service.NewsService;

public class TechViewModel extends ViewModel {
    private final NewsService newsService;

    public TechViewModel(NewsService newsService) {
        this.newsService = newsService;
    }

    public LiveData<Result<Void>> save(News news) {
        MutableLiveData<Result<Void>> liveData = new MutableLiveData<>();

        Result<Void> result = newsService.save(news);

        liveData.setValue(result);

        return liveData;
    }
}
