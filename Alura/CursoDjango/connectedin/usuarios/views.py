from django.contrib.auth import authenticate, login
from django.contrib.auth.models import User
from django.shortcuts import redirect, render
from django.views import View

from perfis.models import Perfil
from usuarios.forms import AutenticaUsuarioForm, RegistraUsuarioForm

# Create your views here.


class AutenticaUsuarioView(View):
    def get(self, request):
        form = AutenticaUsuarioForm()
        return render(request, 'autentica_usuario.html', {'form': form})

    def post(self, request):
        form = AutenticaUsuarioForm(request.POST)
        if not form.is_valid():
            return render(request, 'autentica_usuario.html', {'form': form})

        _, username, senha = form.data.values()

        user = authenticate(request, username=username, password=senha)

        if user is None:
            return redirect('registra_usuario')

        login(request, user)

        return redirect('lista_perfil')


class RegistraUsuarioView(View):
    def get(self, request):
        form = RegistraUsuarioForm()
        return render(request, 'registra_usuario.html', {'form': form})

    def post(self, request):
        form = RegistraUsuarioForm(request.POST)
        if not form.is_valid():
            return render(request, 'registra_usuario.html', {'form': form})

        _, nome, username, email, senha, telefone, empresa = form.data.values()

        usuario, criado = User.objects.get_or_create(username=username,
                                                     email=email)
        if not criado:
            return render(request, 'registra_usuario.html', {'form': form})

        usuario.set_password(senha)
        usuario.save()

        Perfil.objects.create(nome=nome,
                              telefone=telefone,
                              empresa=empresa,
                              usuario=usuario)

        return redirect('autentica_usuario')
