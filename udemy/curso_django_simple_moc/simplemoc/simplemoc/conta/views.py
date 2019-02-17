from django.contrib.auth.decorators import login_required
from django.shortcuts import render, redirect

from .forms import FormularioCadastroUsuario, FormularioEdicaoUsuario


def cadastro(request):
    form = FormularioCadastroUsuario(request.POST or None)
    if request.method == 'POST' and form.is_valid():
        form.save()
        return redirect('core:index')
    contexto = {'form': form}
    return render(request, 'cadastro.html', contexto)


@login_required
def perfil(request):
    form_usuario = FormularioEdicaoUsuario(request.POST or None, instance=request.user)
    if request.method == 'POST' and form_usuario.is_valid():
        form_usuario.save()
    contexto = {'form_usuario': form_usuario}
    return render(request, 'perfil.html', contexto)
