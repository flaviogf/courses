from django.shortcuts import redirect, render

from perfis.models import Perfil

# Create your views here.


def lista(request):
    perfis = Perfil.objects.all()
    return render(request, 'index.html', {'perfis': perfis})


def exibe(request, perfil_id):
    perfil = Perfil.objects.get(id=perfil_id)
    return render(request, 'show.html', {'perfil': perfil})


def convida(request, perfil_id):
    perfil_solicitante = Perfil.objects.get(id=1)
    perfil_convidado = Perfil.objects.get(id=perfil_id)
    perfil_solicitante.convida(perfil_convidado)
    return redirect(lista)
