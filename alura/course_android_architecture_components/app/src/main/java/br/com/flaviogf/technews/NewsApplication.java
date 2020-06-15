package br.com.flaviogf.technews;

import android.app.Application;

import java.util.UUID;

import br.com.flaviogf.technews.models.News;
import br.com.flaviogf.technews.service.MemoryNewsService;
import br.com.flaviogf.technews.service.NewsService;

public class NewsApplication extends Application {
    @Override
    public void onCreate() {
        super.onCreate();

        NewsService newsService = new MemoryNewsService();

        newsService.save(new News(UUID.randomUUID(), "First news", "First news"));
        newsService.save(new News(UUID.randomUUID(), "Second news", "Second news"));
        newsService.save(new News(UUID.randomUUID(), "Third news", "Third news"));
    }
}
