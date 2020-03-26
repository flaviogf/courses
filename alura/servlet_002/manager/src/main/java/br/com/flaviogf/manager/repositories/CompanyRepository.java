package br.com.flaviogf.manager.repositories;

import java.util.Collection;
import java.util.Optional;

import br.com.flaviogf.manager.entities.Company;

public interface CompanyRepository {
    void create(Company company);

    Collection<Company> findAll();

    Optional<Company> findOne(String id);
}