from rest_framework.viewsets import ModelViewSet

from atracoes.api.serializers import AtracaoSerializer
from atracoes.models import Atracao


class AtracaoViewSet(ModelViewSet):
    serializer_class = AtracaoSerializer
    queryset = Atracao.objects.all()
