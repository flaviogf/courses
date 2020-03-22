package br.com.flaviogf.manager;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.UUID;

@WebServlet(urlPatterns = {"/store"})
public class StoreServlet extends HttpServlet {
    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        System.out.println("StoreServlet");

        CompanyRepository companyRepository = new InMemoryCompanyRepository();

        String id = UUID.randomUUID().toString();
        String name = req.getParameter("name");
        Company company = new Company(id, name);
        companyRepository.add(company);

        resp.sendRedirect("/company");
    }
}
