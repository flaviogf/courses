from django import forms


class AutenticaUsuarioForm(forms.Form):
    username = forms.CharField(label='Username', required=True)
    senha = forms.CharField(label='Senha',
                            required=True,
                            widget=forms.PasswordInput)


class RegistraUsuarioForm(forms.Form):
    nome = forms.CharField(label='Nome', required=True)
    username = forms.CharField(label='Username', required=True)
    email = forms.EmailField(label='E-mail', required=True)
    senha = forms.CharField(label='Senha',
                            required=True,
                            widget=forms.PasswordInput)
    telefone = forms.CharField(label='Telefone', required=True)
    empresa = forms.CharField(label='Empresa', required=True)
