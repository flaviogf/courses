package br.com.flaviogf.manager;

import java.util.Collection;

public interface CompanyRepository {
    void add(Company company);

    Collection<Company> findAll();
}
