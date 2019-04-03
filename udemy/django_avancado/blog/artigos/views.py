from django.urls import reverse_lazy
from django.views.generic import DetailView, UpdateView, CreateView
from django.views.generic.list import ListView

from artigos.models import Artigo


class ArtigoCreate(CreateView):
    model = Artigo
    fields = ('titulo', 'conteudo')
    success_url = reverse_lazy('article-list')


class ArtigoListView(ListView):
    model = Artigo
    paginate_by = 1


class ArtigoDetail(DetailView):
    model = Artigo


class ArtigoUpdate(UpdateView):
    model = Artigo
    fields = ('titulo', 'conteudo')
    success_url = reverse_lazy('article-list')
