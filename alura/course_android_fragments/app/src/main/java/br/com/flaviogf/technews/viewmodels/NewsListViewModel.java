package br.com.flaviogf.technews.viewmodels;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import java.util.List;

import br.com.flaviogf.technews.infrastructure.Result;
import br.com.flaviogf.technews.models.News;
import br.com.flaviogf.technews.repositories.NewsRepository;

public class NewsListViewModel extends ViewModel {
    private final NewsRepository newsRepository;

    public NewsListViewModel(NewsRepository newsRepository) {
        this.newsRepository = newsRepository;
    }

    public LiveData<Result<List<News>>> fetch() {
        MutableLiveData<Result<List<News>>> liveData = new MutableLiveData<>();

        Result<List<News>> result = newsRepository.fetch();

        liveData.setValue(result);

        return liveData;
    }
}
