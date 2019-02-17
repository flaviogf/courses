package br.com.flaviogf.cursoreflection.modelos;

public class Usuario {

    @AnotacaoValidaTamanhoMinimo(2)
    private String nome;

    private String email;

    @AnotacaoValidaTamanhoMinimo(8)
    private String senha;

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

    public String getSenha() {
        return senha;
    }

    public void setSenha(String senha) {
        this.senha = senha;
    }
}
