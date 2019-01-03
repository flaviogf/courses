from django import forms
from django.conf import settings
from django.core.mail import send_mail


class FormularioDuvida(forms.Form):
    nome = forms.CharField(
        widget=forms.TextInput(attrs={'class': 'form-control'}),
        max_length=50,
        label="Nome"
    )
    email = forms.EmailField(
        widget=forms.EmailInput(attrs={'class': 'form-control'}),
        label="E-mail"
    )
    mensagem = forms.CharField(
        widget=forms.Textarea(attrs={'class': 'form-control'}),
        label="Mensagem"
    )

    def envia_email(self, curso):
        nome = self.cleaned_data['nome']
        email = self.cleaned_data['email']
        mensagem = self.cleaned_data['mensagem']
        send_mail(
            f'Duvida do curso: {curso.nome}',
            f'Aluno {nome}; Email: {email}; Mensagem: {mensagem}',
            settings.EMAIL_HOST_USER,
            [settings.EMAIL_CONTATO]
        )
