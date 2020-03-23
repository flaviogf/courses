package br.com.flaviogf.manager;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

@WebServlet(urlPatterns = { "/update" })
public class UpdateServlet extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String id = req.getParameter("id");

        CompanyRepository companyRepository = new InMemoryCompanyRepository();

        Company company = companyRepository.find(id).orElseThrow(ServletException::new);

        req.setAttribute("company", company);

        req.getRequestDispatcher("update.jsp").forward(req, resp);
    }

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        Date date = null;

        SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
        try {
            date = format.parse(req.getParameter("date"));
        } catch (ParseException e) {
            throw new ServletException(e);
        }

        String id = req.getParameter("id");
        String name = req.getParameter("name");

        Company company = new Company(id, name, date);

        CompanyRepository companyRepository = new InMemoryCompanyRepository();
        companyRepository.update(company);

        resp.sendRedirect("/");
    }
}
