package br.com.flaviogf.manager;

import java.util.Collection;
import java.util.LinkedHashSet;
import java.util.Set;

public class InMemoryCompanyRepository implements CompanyRepository {
    private static Set<Company> companies = new LinkedHashSet<>();

    @Override
    public void add(Company company) {
        companies.add(company);
    }

    @Override
    public Collection<Company> findAll() {
        return companies;
    }
}
