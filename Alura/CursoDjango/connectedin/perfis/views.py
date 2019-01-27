from django.contrib.auth.decorators import login_required
from django.shortcuts import redirect, render

from perfis.models import Convite, Perfil

# Create your views here.


@login_required
def lista(request):
    perfis = Perfil.objects.all()
    perfil_logado = request.user.perfil
    return render(request, 'index.html', {'perfis': perfis, 'perfil_logado': perfil_logado})


@login_required
def exibe(request, perfil_id):
    perfil = Perfil.objects.get(id=perfil_id)
    return render(request, 'show.html', {'perfil': perfil})


@login_required
def convida(request, perfil_id):
    perfil_solicitante = request.user.perfil
    perfil_convidado = Perfil.objects.get(id=perfil_id)
    perfil_solicitante.convida(perfil_convidado)
    return redirect(lista)


@login_required
def aceita_convite(request, convite_id):
    convite = Convite.objects.get(id=convite_id)
    convite.aceita()
    return redirect(lista)
