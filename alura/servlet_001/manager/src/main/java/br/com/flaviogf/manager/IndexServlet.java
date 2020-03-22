package br.com.flaviogf.manager;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.Collection;

@WebServlet(urlPatterns = {"/", "/company"})
public class IndexServlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        System.out.println("IndexServlet");

        CompanyRepository companyRepository = new InMemoryCompanyRepository();

        Collection<Company> companies = companyRepository.findAll();
        req.setAttribute("companies", companies);

        req.getRequestDispatcher("index.jsp").forward(req, resp);
    }
}
