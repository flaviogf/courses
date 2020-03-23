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
import java.util.UUID;

@WebServlet(urlPatterns = {"/store"})
public class StoreServlet extends HttpServlet {
    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        Date date = null;

        try {
            SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
            date = format.parse(req.getParameter("date"));
        } catch (ParseException e) {
            throw new ServletException(e);
        }

        String id = UUID.randomUUID().toString();
        String name = req.getParameter("name");

        Company company = new Company(id, name, date);

        CompanyRepository companyRepository = new InMemoryCompanyRepository();
        companyRepository.add(company);

        resp.sendRedirect("/");
    }
}
