package br.com.flaviogf.cursofirebase.ui.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.google.android.gms.auth.api.signin.GoogleSignIn;
import com.google.android.gms.auth.api.signin.GoogleSignInAccount;
import com.google.android.gms.auth.api.signin.GoogleSignInClient;
import com.google.android.gms.auth.api.signin.GoogleSignInOptions;
import com.google.android.gms.common.SignInButton;
import com.google.android.gms.common.api.ApiException;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthCredential;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.auth.FirebaseUser;
import com.google.firebase.auth.GoogleAuthProvider;

import br.com.flaviogf.cursofirebase.R;

public class AutenticacaoActivity extends AppCompatActivity {

    private FirebaseAuth mFirebaseAuth;

    private GoogleSignInClient mGoogleSignInClient;

    private ViewHolder mViewHolder;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_autenticacao);
        inicializa();
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (requestCode == 1) {
            Task<GoogleSignInAccount> tarefa = GoogleSignIn.getSignedInAccountFromIntent(data);
            try {
                GoogleSignInAccount resultado = tarefa.getResult(ApiException.class);
                autenticarComGoogleFirebase(resultado);
            } catch (ApiException e) {
                Toast.makeText(AutenticacaoActivity.this, "Falha na autenticação", Toast.LENGTH_LONG).show();
            }
        }
    }

    private void inicializa() {
        mFirebaseAuth = FirebaseAuth.getInstance();
        desconectaUsuarioAutenticado();
        configuraViewHolder();
        configuraAutenticacaoEmailSenha();
        configuraAutenticacaoGoogle();
    }

    private void desconectaUsuarioAutenticado() {
        FirebaseUser usuarioAutenticado = mFirebaseAuth.getCurrentUser();

        if (usuarioAutenticado != null) {
            mFirebaseAuth.signOut();
        }
    }

    private void configuraViewHolder() {
        mViewHolder = new ViewHolder();
        mViewHolder.mEditTextEmail = findViewById(R.id.autenticacao_edittext_email);
        mViewHolder.mEditTextSenha = findViewById(R.id.autenticacao_edittext_senha);
        mViewHolder.mButtonEntrar = findViewById(R.id.autenticacao_button_entrar);
        mViewHolder.mButtonGoogle = findViewById(R.id.autenticacao_button_google);
    }

    private void configuraAutenticacaoEmailSenha() {
        mViewHolder.mButtonEntrar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String email = mViewHolder.mEditTextEmail.getText().toString();
                String senha = mViewHolder.mEditTextSenha.getText().toString();
                mFirebaseAuth.signInWithEmailAndPassword(email, senha).addOnCompleteListener(new OnCompleteListener<AuthResult>() {
                    @Override
                    public void onComplete(@NonNull Task<AuthResult> task) {
                        if (task.isSuccessful()) {
                            FirebaseUser usuario = task.getResult().getUser();
                            Toast.makeText(AutenticacaoActivity.this, usuario.getEmail() + " autenticado com sucesso", Toast.LENGTH_LONG).show();
                        } else {
                            Toast.makeText(AutenticacaoActivity.this, "E-mail ou senha inválidos", Toast.LENGTH_LONG).show();
                        }
                    }
                });
            }
        });
    }

    private void configuraAutenticacaoGoogle() {
        GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DEFAULT_SIGN_IN)
                .requestIdToken(getString(R.string.default_web_client_id))
                .requestEmail()
                .build();

        mGoogleSignInClient = GoogleSignIn.getClient(this, gso);

        mViewHolder.mButtonGoogle.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent signInIntent = mGoogleSignInClient.getSignInIntent();
                startActivityForResult(signInIntent, 1);
            }
        });
    }

    private void autenticarComGoogleFirebase(GoogleSignInAccount conta) {
        AuthCredential credencial = GoogleAuthProvider.getCredential(conta.getIdToken(), null);
        mFirebaseAuth.signInWithCredential(credencial).addOnCompleteListener(new OnCompleteListener<AuthResult>() {
            @Override
            public void onComplete(@NonNull Task<AuthResult> task) {
                try {
                    AuthResult resultado = task.getResult(ApiException.class);
                    FirebaseUser usuario = resultado.getUser();
                    Toast.makeText(AutenticacaoActivity.this, usuario.getEmail() + " autenticado com sucesso", Toast.LENGTH_LONG).show();
                } catch (ApiException e) {
                    Toast.makeText(AutenticacaoActivity.this, "Não foi possível autenticar", Toast.LENGTH_LONG).show();
                }
            }
        });
    }

    private static class ViewHolder {
        EditText mEditTextEmail;
        EditText mEditTextSenha;
        Button mButtonEntrar;
        SignInButton mButtonGoogle;
    }
}
