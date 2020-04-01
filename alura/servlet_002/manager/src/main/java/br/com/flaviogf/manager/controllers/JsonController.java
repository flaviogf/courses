package br.com.flaviogf.manager.controllers;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.google.gson.Gson;

import br.com.flaviogf.manager.entities.Company;
import br.com.flaviogf.manager.repositories.CompanyRepository;
import br.com.flaviogf.manager.repositories.InMemoryCompanyRepository;

public class JsonController {
    private final CompanyRepository companyRepository;

    public JsonController() {
        companyRepository = new InMemoryCompanyRepository();
    }

    public void index(HttpServletRequest request, HttpServletResponse response) throws IOException {
        PrintWriter writer = response.getWriter();

        List<Company> companies = new ArrayList<>(companyRepository.findAll());

        Gson gson = new Gson();

        String json = gson.toJson(companies);

        response.setHeader("Content-Type", "application/json");

        writer.print(json);
    }
}