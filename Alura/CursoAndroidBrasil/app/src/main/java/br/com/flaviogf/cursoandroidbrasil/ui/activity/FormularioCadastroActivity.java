package br.com.flaviogf.cursoandroidbrasil.ui.activity;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.TextInputLayout;
import android.support.v7.app.AppCompatActivity;
import android.widget.EditText;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import br.com.flaviogf.cursoandroidbrasil.R;
import br.com.flaviogf.cursoandroidbrasil.formatador.FormatadorTelefone;
import br.com.flaviogf.cursoandroidbrasil.validador.Validador;
import br.com.flaviogf.cursoandroidbrasil.validador.ValidadorTelefone;
import br.com.flaviogf.cursoandroidbrasil.validador.ValidadorVazio;

public class FormularioCadastroActivity extends AppCompatActivity {

    private List<Validador> validadores = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_formulario_cadastro);
        inicializa();
    }

    private void inicializa() {
        configuraCampoNomeCompleto();
        configuraCampoTelefone();
        configuraBtnCadastro();
    }

    private void configuraBtnCadastro() {
        FloatingActionButton btnCadastrar = findViewById(R.id.formulario_cadastro_btn_cadastrar);
        btnCadastrar.setOnClickListener(v -> cadastra());
    }

    private void configuraCampoNomeCompleto() {
        final TextInputLayout textInputNomeCompleto = findViewById(R.id.formulario_cadastro_campo_nome_completo);
        final ValidadorVazio validador = new ValidadorVazio(textInputNomeCompleto);
        validadores.add(validador);
        EditText editTextNomeCompleto = textInputNomeCompleto.getEditText();
        editTextNomeCompleto.setOnFocusChangeListener((v, hasFocus) -> {
            if (hasFocus) return;
            validador.valida();
        });
    }

    private void configuraCampoTelefone() {
        final TextInputLayout textInputTelefone = findViewById(R.id.formulario_cadastro_campo_telefone);
        final ValidadorTelefone validador = new ValidadorTelefone(textInputTelefone);
        validadores.add(validador);
        final EditText editTextTelefone = textInputTelefone.getEditText();
        editTextTelefone.setOnFocusChangeListener((v, hasFocus) -> {
            FormatadorTelefone formatador = new FormatadorTelefone(editTextTelefone.getText().toString());
            if (hasFocus) {
                editTextTelefone.setText(formatador.remove());
                return;
            }
            if (validador.valida()) {
                editTextTelefone.setText(formatador.adiciona());
            }
        });
    }

    private void cadastra() {
        if (!validaTodosCampos()) return;
        Toast.makeText(this, "Cliente cadastrado", Toast.LENGTH_SHORT).show();
    }

    private boolean validaTodosCampos() {
        return validadores.stream().map(Validador::valida).reduce((acumulador, valor) -> acumulador && valor).get();
    }
}
