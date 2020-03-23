package br.com.flaviogf.manager;

import java.util.*;

public class InMemoryCompanyRepository implements CompanyRepository {
    private static Map<String, Company> companyMap = new LinkedHashMap<>();

    @Override
    public void create(Company company) {
        companyMap.put(company.getId(), company);
    }

    @Override
    public Collection<Company> findAll() {
        return companyMap.values();
    }

    @Override
    public Optional<Company> find(String id) {
        if (!companyMap.containsKey(id)) {
            return Optional.empty();
        }

        Company company = companyMap.get(id);

        return Optional.of(company);
    }

    @Override
    public void destroy(String id) {
        companyMap.remove(id);
    }
}
