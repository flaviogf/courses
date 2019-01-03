from django.urls import path

from .views import VagaView, VagaDetalheView

app_name = __name__

urlpatterns = [
    path('vagas', VagaView.as_view()),
    path('vagas/<int:pk>', VagaDetalheView.as_view())
]
