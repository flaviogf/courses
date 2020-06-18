package br.com.flaviogf.technews.viewmodels;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import br.com.flaviogf.technews.infrastructure.Result;
import br.com.flaviogf.technews.models.News;
import br.com.flaviogf.technews.repositories.NewsRepository;

public class NewsViewModel extends ViewModel {
    private final NewsRepository newsRepository;

    public NewsViewModel(NewsRepository newsRepository) {
        this.newsRepository = newsRepository;
    }

    public LiveData<Result<Void>> save(News news) {
        MutableLiveData<Result<Void>> liveData = new MutableLiveData<>();

        Result<Void> result = newsRepository.save(news);

        liveData.setValue(result);

        return liveData;
    }

    public LiveData<Result<News>> fetchOne(String id) {
        MutableLiveData<Result<News>> liveData = new MutableLiveData<>();

        Result<News> result = newsRepository.fetchOne(id);

        liveData.setValue(result);

        return liveData;
    }
}
