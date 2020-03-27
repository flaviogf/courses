package br.com.flaviogf.manager.controllers;

import br.com.flaviogf.manager.entities.User;
import br.com.flaviogf.manager.repositories.InMemoryUserRepository;
import br.com.flaviogf.manager.repositories.UserRepository;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.Optional;

public class LoginController {
    private UserRepository userRepository;

    public LoginController() {
        userRepository = new InMemoryUserRepository();
    }

    public void index(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        req.getRequestDispatcher("/WEB-INF/views/login/index.jsp").forward(req, resp);
    }

    public void store(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String username = req.getParameter("username");
        String password = req.getParameter("password");

        Optional<User> user = userRepository.findOne(username);

        if (!user.isPresent()) {
            req.getRequestDispatcher("/WEB-INF/views/login/index.jsp").forward(req, resp);
            return;
        }

        if (!user.get().authenticate(password)) {
            req.getRequestDispatcher("/WEB-INF/views/login/index.jsp").forward(req, resp);
            return;
        }

        req.getSession().setAttribute("user", user.get());

        resp.sendRedirect("/company");
    }
}
