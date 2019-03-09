from rest_framework.viewsets import ModelViewSet

from avaliacoes.api.serializers import AvaliacaoSerializer
from avaliacoes.models import Avaliacao


class AvaliacaoViewSet(ModelViewSet):
    serializer_class = AvaliacaoSerializer
    queryset = Avaliacao.objects.all()
