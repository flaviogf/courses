from django.urls import path

from recipes import views


urlpatterns = [
    path('', views.index, name='index'),
    path('recipe', views.show, name='show')
]
