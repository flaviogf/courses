package br.com.flaviogf.cursoandroidbrasil.formatador;

public class FormatadorTelefone {

    private String texto;

    public FormatadorTelefone(String texto) {
        this.texto = texto;
    }

    public String adiciona() {
        return texto.replaceAll("(\\d{2})(\\d{4,5})(\\d{4})", "($1) $2-$3");
    }

    public String remove() {
        return texto.replaceAll("[() -]", "");
    }
}
