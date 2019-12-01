from django.urls import path

from recipes import views

urlpatterns = [
    path('', views.index, name='index'),
    path('recipe/<int:pk>', views.show, name='show')
]
