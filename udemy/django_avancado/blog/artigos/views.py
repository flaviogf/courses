from django.shortcuts import render

from django.views.generic.list import ListView

from artigos.models import Artigo


class ArtigoListView(ListView):
    model = Artigo
    paginate_by = 1


