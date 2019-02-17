package br.com.flaviogf.utils;

import javax.faces.application.FacesMessage;
import javax.faces.context.FacesContext;

public class BeanUtils {

    public static void exibeMensagem(String texto) {
        FacesContext context = FacesContext.getCurrentInstance();
        context.addMessage(null, new FacesMessage(texto));
        context.getExternalContext().getFlash().setKeepMessages(true);
    }
}
