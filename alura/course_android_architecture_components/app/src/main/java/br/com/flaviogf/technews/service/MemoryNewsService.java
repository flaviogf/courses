package br.com.flaviogf.technews.service;

import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

import br.com.flaviogf.technews.infrastructure.Result;
import br.com.flaviogf.technews.models.News;

public class MemoryNewsService implements NewsService {
    private final static NewsService instance = new MemoryNewsService();

    private final static Map<UUID, News> news = new HashMap<>();

    @Override
    public Result<Void> save(News news) {
        MemoryNewsService.news.put(news.getId(), news);

        return Result.ok();
    }

    @Override
    public Result<Void> remove(News news) {
        MemoryNewsService.news.remove(news.getId());

        return Result.ok();
    }

    @Override
    public Result<Collection<News>> fetch() {
        Collection<News> unmodifiableNews = Collections.unmodifiableCollection(news.values());

        return Result.ok(unmodifiableNews);
    }

    @Override
    public Result<News> fetchOne(UUID id) {
        if (!news.containsKey(id)) {
            return Result.fail("News does not exist");
        }

        News news = MemoryNewsService.news.get(id);

        return Result.ok(news);
    }

    public static NewsService getInstance() {
        return instance;
    }
}
