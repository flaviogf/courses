package br.com.flaviogf.casadocodigo;

import org.springframework.web.servlet.support.AbstractAnnotationConfigDispatcherServletInitializer;

public class Program extends AbstractAnnotationConfigDispatcherServletInitializer {

    @Override
    protected Class<?>[] getRootConfigClasses() {
        return null;
    }

    @Override
    protected Class<?>[] getServletConfigClasses() {
        return new Class[] { Startup.class };
    }

    @Override
    protected String[] getServletMappings() {
        return new String[] { "/" };
    }
}
