from django.urls import path

from .views import index

app_name = __name__

urlpatterns = [
    path('', index, name='index')
]
