package br.com.flaviogf.manager;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet(urlPatterns = {"/update"})
public class UpdateServlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String id = req.getParameter("id");

        CompanyRepository companyRepository = new InMemoryCompanyRepository();

        Company company = companyRepository.find(id).orElseThrow(ServletException::new);

        req.setAttribute("company", company);

        req.getRequestDispatcher("update.jsp").forward(req, resp);
    }
}
