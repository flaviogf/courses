from django.urls import path, re_path

from perfis import views

urlpatterns = [
    path('', views.lista, name='lista_perfil'),
    re_path(r'(?P<perfil_id>\d+)$', views.exibe, name='exibe_perfil'),
    re_path(r'(?P<perfil_id>\d+)/convida$',
            views.convida, name='convida_perfil')
]
