from django.urls import path, re_path

from .views import index, detalhe

app_name = __name__

urlpatterns = [
    path('', index, name='index'),
    # re_path(r'/detalhe/(?P<pk>\d+)', detalhe, name='detalhe'),
    re_path(r'detalhe/(?P<slug>[\w_-]+)$', detalhe, name='detalhe')
]
