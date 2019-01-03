from django.contrib.auth import views as auth_views
from django.urls import path

from .views import cadastro, perfil

app_name = __file__

urlpatterns = [
    path('', perfil, name='perfil'),
    path('login/', auth_views.LoginView.as_view(template_name='login.html'), name='login'),
    path('sair', auth_views.logout_then_login, name='sair'),
    path('cadastro/', cadastro, name='cadastro')
]
