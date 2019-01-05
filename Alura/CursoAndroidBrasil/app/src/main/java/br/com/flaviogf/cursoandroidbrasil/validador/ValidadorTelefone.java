package br.com.flaviogf.cursoandroidbrasil.validador;

import android.support.design.widget.TextInputLayout;

import br.com.flaviogf.cursoandroidbrasil.formatador.FormatadorTelefone;

public class ValidadorTelefone implements Validador {

    private final TextInputLayout textInputLayout;
    private final ValidadorVazio validadorVazio;

    public ValidadorTelefone(TextInputLayout textInputLayout) {
        this.textInputLayout = textInputLayout;
        this.validadorVazio = new ValidadorVazio(textInputLayout);
    }

    private boolean validaTelefone() {
        if (!validadorVazio.valida()) return false;
        String telefone = textInputLayout.getEditText().getText().toString();
        String telefoneSemFormatacao = new FormatadorTelefone(telefone).remove();
        if (telefoneSemFormatacao.length() < 10 || telefoneSemFormatacao.length() > 11) {
            textInputLayout.setError("Telefone deve conter entre 10 e 11 digitos");
            return false;
        }
        return true;
    }

    @Override
    public boolean valida() {
        return validaTelefone();
    }
}
