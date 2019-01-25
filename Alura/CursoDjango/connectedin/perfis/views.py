from django.shortcuts import render
from perfis.models import Perfil

# Create your views here.


def index(request):
    return render(request, 'index.html')


def show(request, perfil_id):
    perfil = Perfil(perfil_id, 'Flavio', '1111-1111', 'Flaviogf')
    return render(request, 'show.html', {'perfil': perfil})
