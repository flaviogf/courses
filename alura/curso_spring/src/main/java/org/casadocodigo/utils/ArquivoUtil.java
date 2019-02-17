package org.casadocodigo.utils;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.web.multipart.MultipartFile;

import javax.servlet.http.HttpServletRequest;
import java.io.File;
import java.io.IOException;

@Component
public class ArquivoUtil {

    @Autowired
    private HttpServletRequest requestHandlerServlet;

    public String salva(MultipartFile multipartFile) {
        try {
            String nome = multipartFile.getOriginalFilename();
            String diretorio = requestHandlerServlet.getServletContext().getRealPath("/" + nome);
            File file = new File(diretorio);
            multipartFile.transferTo(file);
            return nome;
        } catch (IOException e) {
            throw new RuntimeException();
        }
    }
}
