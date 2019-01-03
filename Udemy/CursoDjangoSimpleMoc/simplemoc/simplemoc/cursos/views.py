from django.shortcuts import render, get_object_or_404

from .forms import FormularioDuvida
from .models import Curso


def index(request):
    contexto = {'cursos': Curso.objects.all()}
    return render(request, 'cursos/index.html', contexto)


def detalhe(request, slug):
    form = FormularioDuvida(request.POST or None)
    curso = get_object_or_404(Curso, slug=slug)
    contexto = {}
    if request.method == 'POST' and form.is_valid():
        form.envia_email(curso)
        form = FormularioDuvida()
        contexto['sucesso'] = True
    contexto['form'] = form
    contexto['curso'] = curso
    return render(request, 'cursos/detalhe.html', contexto)
