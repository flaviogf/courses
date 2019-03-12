from django_filters.rest_framework import DjangoFilterBackend
from rest_framework.filters import SearchFilter
from rest_framework.viewsets import ModelViewSet

from avaliacoes.api.serializers import AvaliacaoSerializer
from avaliacoes.models import Avaliacao


class AvaliacaoViewSet(ModelViewSet):
    serializer_class = AvaliacaoSerializer
    queryset = Avaliacao.objects.all()
    filter_backends = (DjangoFilterBackend, SearchFilter)
    filterset_fields = ("nota", "data")
    search_fields = ("comentario", "$usuario__username")
