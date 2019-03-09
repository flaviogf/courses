from rest_framework.decorators import action
from rest_framework.response import Response
from rest_framework.viewsets import ModelViewSet

from core.api.serializers import PontoTuristicoSerializer
from core.models import PontoTuristico


class PontoTuristicoViewSet(ModelViewSet):
    serializer_class = PontoTuristicoSerializer

    def get_queryset(self):
        return PontoTuristico.objects.filter(aprovado=True)

    @action(methods=['POST'], detail=True)
    def denuncia(self, request, pk):
        ponto_turistico = PontoTuristico.objects.get(ponto_turistico_id=pk)
        return Response({'mensagem': f'{ponto_turistico.nome} denunciado'})
