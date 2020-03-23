package br.com.flaviogf.manager;

import java.util.Collection;
import java.util.Optional;

public interface CompanyRepository {
    void add(Company company);

    Collection<Company> findAll();

    Optional<Company> find(String id);
}
