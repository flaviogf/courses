package br.com.flaviogf.manager;

import java.util.Collection;
import java.util.Optional;

public interface CompanyRepository {
    void create(Company company);

    Collection<Company> findAll();

    Optional<Company> find(String id);

    void destroy(String id);

    void update(Company company);
}
