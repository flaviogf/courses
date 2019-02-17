package br.com.fernandes.flavio.whatsappclonev2.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;

import com.google.firebase.auth.FirebaseAuth;

import br.com.fernandes.flavio.whatsappclonev2.R;
import br.com.fernandes.flavio.whatsappclonev2.service.FirebaseService;

public class PrincipalActivity extends AppCompatActivity {
    private FirebaseAuth autenticacao;
    private Toolbar toolbar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_principal);

        autenticacao = FirebaseService.getAutenticacao();

        toolbar = (Toolbar) findViewById(R.id.toolbar);

        iniciarToolbar();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_principal, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.item_sair:
                deslogarUsuario();
                return true;
            default:
                return super.onOptionsItemSelected(item);
        }
    }

    private void iniciarToolbar() {
        toolbar.setTitle("WhatsApp");
        setSupportActionBar(toolbar);
    }

    private void deslogarUsuario() {
        Intent intent = new Intent(this, MainActivity.class);
        autenticacao.signOut();
        startActivity(intent);
        finish();
    }
}
