package br.com.flaviogf.manager.repositories;

import br.com.flaviogf.manager.entities.Company;

import java.util.Collection;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Optional;

public class InMemoryCompanyRepository implements CompanyRepository {
    private static Map<String, Company> companies = new LinkedHashMap<>();

    @Override
    public void create(Company company) {
        companies.put(company.getId(), company);
    }

    @Override
    public Collection<Company> findAll() {
        return companies.values();
    }

    @Override
    public Optional<Company> findOne(String id) {
        Company company = companies.get(id);

        if (company == null) {
            return Optional.empty();
        }

        return Optional.of(company);
    }
}