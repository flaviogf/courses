package br.com.flaviogf.cursoandroidbrasil.validador;

import android.support.design.widget.TextInputLayout;

public class ValidadorVazio implements Validador {

    private final TextInputLayout textInputLayout;

    public ValidadorVazio(TextInputLayout textInputLayout) {
        this.textInputLayout = textInputLayout;
    }

    private boolean validaCampoVazio() {
        String telefone = textInputLayout.getEditText().getText().toString();
        if (telefone.isEmpty()) {
            textInputLayout.setError("Campo obrigatório");
            return false;
        }
        removeErro();
        return true;
    }

    private void removeErro() {
        textInputLayout.setErrorEnabled(false);
        textInputLayout.setError(null);
    }

    @Override
    public boolean valida() {
        return validaCampoVazio();
    }
}
