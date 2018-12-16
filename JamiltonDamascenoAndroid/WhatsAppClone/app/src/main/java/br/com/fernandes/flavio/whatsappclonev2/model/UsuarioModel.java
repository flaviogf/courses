package br.com.fernandes.flavio.whatsappclonev2.model;

import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.Exclude;

import br.com.fernandes.flavio.whatsappclonev2.service.FirebaseService;

public class UsuarioModel {
    private String id;
    private String nome;
    private String email;
    private String senha;

    @Exclude
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    @Exclude
    public String getSenha() {
        return senha;
    }

    public void setSenha(String senha) {
        this.senha = senha;
    }

    public void salvar() {
        DatabaseReference referenciaFirebase = FirebaseService.getReferenciaFirebase();
        referenciaFirebase.child("usuarios").child(getId()).setValue(this);
    }
}
