from django.contrib.auth import logout
from django.contrib.auth import views as auth_views
from django.urls import path

from usuarios.views import AutenticaUsuarioView, RegistraUsuarioView

urlpatterns = [
    path('registra', RegistraUsuarioView.as_view(), name='registra_usuario'),
    path('autentica', AutenticaUsuarioView.as_view(), name='autentica_usuario'),
    path('logout', auth_views.LogoutView.as_view(), name='logout')
]
