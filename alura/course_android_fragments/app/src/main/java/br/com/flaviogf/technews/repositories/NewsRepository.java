package br.com.flaviogf.technews.repositories;

import java.util.List;

import br.com.flaviogf.technews.infrastructure.Result;
import br.com.flaviogf.technews.models.News;

public interface NewsRepository {
    Result<Void> save(News news);

    Result<Void> remove(News news);

    Result<List<News>> fetch();

    Result<News> fetchOne(String id);
}
