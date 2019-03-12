from rest_framework.authentication import TokenAuthentication
from rest_framework.permissions import IsAuthenticated
from rest_framework.viewsets import ModelViewSet

from enderecos.api.serializers import EnderecoSerializer
from enderecos.models import Endereco


class EnderecoViewSet(ModelViewSet):
    authentication_classes = (TokenAuthentication,)
    permission_classes = (IsAuthenticated,)
    serializer_class = EnderecoSerializer
    queryset = Endereco.objects.all()
