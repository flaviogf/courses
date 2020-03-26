package br.com.flaviogf.manager.repositories;

import java.util.Collection;
import java.util.LinkedHashMap;
import java.util.Map;

import br.com.flaviogf.manager.entities.Company;

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
}