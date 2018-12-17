package br.com.fernandes.flavio.whatsappclonev2.activity;

import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseAuthInvalidCredentialsException;
import com.google.firebase.auth.FirebaseAuthUserCollisionException;
import com.google.firebase.auth.FirebaseAuthWeakPasswordException;
import com.google.firebase.auth.FirebaseUser;

import br.com.fernandes.flavio.whatsappclonev2.R;
import br.com.fernandes.flavio.whatsappclonev2.model.UsuarioModel;
import br.com.fernandes.flavio.whatsappclonev2.service.FirebaseService;

public class CadastrarActivity extends AppCompatActivity {

    private Button btnCadastar;
    private EditText editNome;
    private EditText editEmail;
    private EditText editSenha;
    private FirebaseAuth autenticacao;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cadastrar);

        autenticacao = FirebaseService.getAutenticacao();

        btnCadastar = (Button) findViewById(R.id.btnCadastrar);
        editNome = (EditText) findViewById(R.id.editNome);
        editEmail = (EditText) findViewById(R.id.editEmail);
        editSenha = (EditText) findViewById(R.id.editSenha);

        btnCadastar.setOnClickListener(onClickBtnCadastar);
    }

    private View.OnClickListener onClickBtnCadastar = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            try {
                UsuarioModel usuario = new UsuarioModel();
                usuario.setNome(editNome.getText().toString());
                usuario.setEmail(editEmail.getText().toString());
                usuario.setSenha(editSenha.getText().toString());
                cadastra(usuario);
            } catch (Exception e) {
                Toast.makeText(CadastrarActivity.this, "Informe todos os dados", Toast.LENGTH_SHORT).show();
            }
        }
    };

    private void cadastra(final UsuarioModel usuario) {
        autenticacao.createUserWithEmailAndPassword(usuario.getEmail(), usuario.getSenha())
                .addOnCompleteListener(this, new OnCompleteListener<AuthResult>() {
                    @Override
                    public void onComplete(@NonNull Task<AuthResult> task) {
                        if (task.isSuccessful()) {
                            FirebaseUser user = task.getResult().getUser();

                            usuario.setId(user.getUid());

                            usuario.salvar();

                            autenticacao.signOut();

                            finish();

                            Toast.makeText(CadastrarActivity.this, "Usuario cadastrado", Toast.LENGTH_SHORT).show();
                        } else {
                            String erro;

                            try {
                                throw task.getException();
                            } catch (FirebaseAuthWeakPasswordException e) {
                                erro = "Digite uma senha mais forte";
                            } catch (FirebaseAuthInvalidCredentialsException e) {
                                erro = "Digite um email valido";
                            } catch (FirebaseAuthUserCollisionException e) {
                                erro = "E-mail ja cadastrado";
                            } catch (Exception e) {
                                erro = "Erro ao cadastrar";
                            }

                            Toast.makeText(CadastrarActivity.this, erro, Toast.LENGTH_SHORT).show();
                        }
                    }
                });
    }
}
