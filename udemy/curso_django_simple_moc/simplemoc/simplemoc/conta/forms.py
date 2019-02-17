from django import forms
from django.contrib.auth.forms import UserCreationForm
from django.contrib.auth.models import User


class FormularioCadastroUsuario(UserCreationForm):
    email = forms.EmailField(label='E-mail')

    def clean_email(self):
        email = self.cleaned_data['email']
        if not User.objects.filter(email=email).exists():
            return email
        raise forms.ValidationError('Este email já esta sendo utilizado')

    def save(self, commit=False):
        usuario = super().save(commit=False)
        usuario.email = self.cleaned_data['email']
        usuario.save()
        return usuario


class FormularioEdicaoUsuario(forms.ModelForm):
    class Meta:
        model = User
        fields = ('first_name', 'last_name', 'email')
