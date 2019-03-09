from rest_framework.viewsets import ModelViewSet

from enderecos.api.serializers import EnderecoSerializer
from enderecos.models import Endereco


class EnderecoViewSet(ModelViewSet):
    serializer_class = EnderecoSerializer
    queryset = Endereco.objects.all()
