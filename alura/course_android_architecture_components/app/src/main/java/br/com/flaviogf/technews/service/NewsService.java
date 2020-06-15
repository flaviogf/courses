package br.com.flaviogf.technews.service;

import java.util.Collection;
import java.util.UUID;

import br.com.flaviogf.technews.infrastructure.Result;
import br.com.flaviogf.technews.models.News;

public interface NewsService {
    Result<Void> save(News news);

    Result<Collection<News>> fetch();

    Result<News> fetchOne(UUID id);
}
