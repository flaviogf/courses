package br.com.flaviogf.manager.controllers;

import br.com.flaviogf.manager.entities.Company;
import br.com.flaviogf.manager.repositories.CompanyRepository;
import br.com.flaviogf.manager.repositories.InMemoryCompanyRepository;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.UUID;

public class CompanyController {
    private CompanyRepository companyRepository;

    public CompanyController() {
        companyRepository = new InMemoryCompanyRepository();
    }

    public void index(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        final List<Company> companies = new ArrayList<>(companyRepository.findAll());
        req.setAttribute("companies", companies);
        req.getRequestDispatcher("/WEB-INF/views/company/index.jsp").forward(req, resp);
    }

    public void create(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.getRequestDispatcher("/WEB-INF/views/company/index.jsp").forward(req, resp);
    }

    public void store(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        final String id = UUID.randomUUID().toString();
        final String name = req.getParameter("name");
        final Company company = new Company(id, name, new Date());
        companyRepository.create(company);
        resp.sendRedirect("/company");
    }

    public void edit(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        final String id = req.getParameter("id");
        final Company company = companyRepository.findOne(id).orElseThrow(RuntimeException::new);
        req.setAttribute("company", company);
        req.getRequestDispatcher("/WEB-INF/views/company/edit.jsp").forward(req, resp);
    }
}