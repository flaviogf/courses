package br.com.flaviogf.casadocodigo.infrastructure;

import java.io.File;
import java.io.IOException;
import java.nio.file.Paths;

import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.web.multipart.MultipartFile;

@Component
public class FileSaver {
    @Autowired
    private HttpServletRequest request;

    public String write(String folder, MultipartFile file) {
        String path = request.getServletContext().getRealPath(folder);

        String relativePath = getRelativePath(file);

        String absolutePath = getAbsolutePath(path, relativePath);

        try {
            file.transferTo(new File(absolutePath));
        } catch (Exception e) {
            throw new RuntimeException(e);
        }

        return relativePath;
    }

    private String getRelativePath(MultipartFile file) {
        StringBuilder builder = new StringBuilder();
        builder.append(File.separator);
        builder.append(file.getOriginalFilename());
        return builder.toString();
    }

    private String getAbsolutePath(String folder, String file) {
        StringBuilder builder = new StringBuilder();
        builder.append(folder);
        builder.append(file);
        return builder.toString();
    }
}
