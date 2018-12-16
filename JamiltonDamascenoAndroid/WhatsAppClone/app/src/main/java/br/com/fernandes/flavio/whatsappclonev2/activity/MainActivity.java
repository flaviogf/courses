package br.com.fernandes.flavio.whatsappclonev2.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;

import br.com.fernandes.flavio.whatsappclonev2.R;
import br.com.fernandes.flavio.whatsappclonev2.model.UsuarioModel;
import br.com.fernandes.flavio.whatsappclonev2.service.FirebaseService;

public class MainActivity extends AppCompatActivity {
    private Button btnEntar;
    private EditText editEmail;
    private EditText editSenha;
    private TextView txtCadastrar;
    private FirebaseAuth autenticacao;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        autenticacao = FirebaseService.getAutenticacao();

        verificarAutenticacao();

        btnEntar = (Button) findViewById(R.id.btnEntrar);
        editEmail = (EditText) findViewById(R.id.editEmail);
        editSenha = (EditText) findViewById(R.id.editSenha);
        txtCadastrar = (TextView) findViewById(R.id.txtCadastrar);

        btnEntar.setOnClickListener(onClickBtnEntar);
        txtCadastrar.setOnClickListener(onClickTxtCadastar);
    }

    private View.OnClickListener onClickBtnEntar = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            try {
                UsuarioModel usuario = new UsuarioModel();
                usuario.setEmail(editEmail.getText().toString());
                usuario.setSenha(editSenha.getText().toString());

                autenticacao.signInWithEmailAndPassword(usuario.getEmail(), usuario.getSenha())
                        .addOnCompleteListener(MainActivity.this, new OnCompleteListener<AuthResult>() {
                            @Override
                            public void onComplete(@NonNull Task<AuthResult> task) {
                                if (task.isSuccessful()) {
                                    Intent intent = new Intent(MainActivity.this, PrincipalActivity.class);

                                    startActivity(intent);

                                    Toast.makeText(MainActivity.this, "Usuario conectado", Toast.LENGTH_SHORT).show();
                                } else {
                                    Toast.makeText(MainActivity.this, "Não foi possivel conectar", Toast.LENGTH_SHORT).show();
                                }
                            }
                        });
            } catch (Exception e) {
                Toast.makeText(MainActivity.this, "Informe os dados corretamente", Toast.LENGTH_SHORT).show();
            }
        }
    };

    private View.OnClickListener onClickTxtCadastar = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Intent intent = new Intent(MainActivity.this, CadastrarActivity.class);
            startActivity(intent);
        }
    };

    private void verificarAutenticacao() {
        if (autenticacao.getCurrentUser() != null) {
            startActivity(new Intent(MainActivity.this, PrincipalActivity.class));
        }
    }
}
