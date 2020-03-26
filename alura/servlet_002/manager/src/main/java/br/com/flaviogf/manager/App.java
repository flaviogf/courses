package br.com.flaviogf.manager;

import java.io.IOException;
import java.lang.reflect.Method;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import br.com.flaviogf.manager.extensions.StringExtensions;

@WebServlet(urlPatterns = { "/" })
public class App extends HttpServlet {
    private String requestURI;
    private String controllerName;
    private Object controller;
    private String methodName;
    private Method action;

    @Override
    protected void service(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        requestURI = req.getRequestURI();

        try {
            getControllerName();
            getController();
            getMethodName();
            getMethod();
            action.invoke(controller, req, resp);
        } catch (Exception e) {
            e.printStackTrace();
            resp.setStatus(404);
        }
    }

    private void getControllerName() {
        final Pattern pattern = Pattern.compile("(\\w+)");
        final Matcher matcher = pattern.matcher(requestURI);
        controllerName = StringExtensions.toTitleCase(matcher.find() ? matcher.group(1) : "");
    }

    private void getController() throws Exception {
        final String template = "br.com.flaviogf.manager.controllers.%sController";
        final Class<?> clazz = Class.forName(String.format(template, controllerName));
        controller = clazz.getDeclaredConstructor().newInstance();
    }

    private void getMethodName() {
        final Pattern pattern = Pattern.compile("(\\w+)/(\\w+)");
        final Matcher matcher = pattern.matcher(requestURI);
        methodName = matcher.find() ? matcher.group(2) : "index";
    }

    private void getMethod() throws Exception {
        final String template = "br.com.flaviogf.manager.controllers.%sController";
        final Class<?> clazz = Class.forName(String.format(template, controllerName));
        action = clazz.getDeclaredMethod(methodName, HttpServletRequest.class, HttpServletResponse.class);
    }
}