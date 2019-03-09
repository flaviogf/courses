"""pontos_turisticos URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/2.1/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.contrib import admin
from django.urls import include, path
from rest_framework.routers import DefaultRouter

from atracoes.api.viewsets import AtracaoViewSet
from avaliacoes.api.viewsets import AvaliacaoViewSet
from comentarios.api.viewsets import ComentarioViewSet
from core.api.viewsets import PontoTuristicoViewSet
from enderecos.api.viewsets import EnderecoViewSet

router = DefaultRouter()
router.register(r"pontos-turisticos", PontoTuristicoViewSet)
router.register(r"atracoes", AtracaoViewSet)
router.register(r"avaliacoes", AvaliacaoViewSet)
router.register(r"comentarios", ComentarioViewSet)
router.register(r"enderecos", EnderecoViewSet)

urlpatterns = [path("", include(router.urls)), path("admin/", admin.site.urls)]
