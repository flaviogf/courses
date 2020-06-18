package br.com.flaviogf.technews.repositories;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import br.com.flaviogf.technews.infrastructure.Result;
import br.com.flaviogf.technews.models.News;

public class MemoryNewsRepository implements NewsRepository {
    private final static Map<String, News> news = new HashMap<>();

    @Override
    public Result<Void> save(News news) {
        MemoryNewsRepository.news.put(news.getId(), news);

        return Result.ok();
    }

    @Override
    public Result<Void> remove(News news) {
        MemoryNewsRepository.news.remove(news.getId());

        return Result.ok();
    }

    @Override
    public Result<List<News>> fetch() {
        List<News> unmodifiableNews = Collections.unmodifiableList(new ArrayList<>(MemoryNewsRepository.news.values()));

        return Result.ok(unmodifiableNews);
    }

    @Override
    public Result<News> fetchOne(String id) {
        if (!MemoryNewsRepository.news.containsKey(id)) {
            return Result.fail("News does not exist");
        }

        News news = MemoryNewsRepository.news.get(id);

        return Result.ok(news);
    }
}
