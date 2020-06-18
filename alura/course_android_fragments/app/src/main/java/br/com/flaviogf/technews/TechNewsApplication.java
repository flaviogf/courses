package br.com.flaviogf.technews;

import android.app.Application;

import java.util.UUID;

import br.com.flaviogf.technews.models.News;
import br.com.flaviogf.technews.repositories.MemoryNewsRepository;
import br.com.flaviogf.technews.repositories.NewsRepository;

public class TechNewsApplication extends Application {
    @Override
    public void onCreate() {
        super.onCreate();

        NewsRepository newsRepository = new MemoryNewsRepository();

        newsRepository.save(new News(UUID.randomUUID().toString(), "First news", "First news description"));
        newsRepository.save(new News(UUID.randomUUID().toString(), "Second news", "Second news description"));
    }
}
