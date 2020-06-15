package br.com.flaviogf.technews.viewmodels;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.List;

import br.com.flaviogf.technews.infrastructure.Result;
import br.com.flaviogf.technews.models.News;
import br.com.flaviogf.technews.service.NewsService;

public class TechsViewModel extends ViewModel {
    private final MutableLiveData<Result<List<News>>> liveData = new MutableLiveData<>();

    private final NewsService newsService;

    public TechsViewModel(NewsService newsService) {
        this.newsService = newsService;
    }

    public LiveData<Result<List<News>>> fetch() {
        Result<Collection<News>> result = newsService.fetch();

        if (result.isFailure()) {
            liveData.setValue(Result.fail(result.getMessage()));

            return liveData;
        }

        List<News> news = new ArrayList<>(result.getValue());

        Collections.sort(news, (first, second) -> first.getTitle().compareTo(second.getTitle()));

        liveData.setValue(Result.ok(news));

        return liveData;
    }
}
