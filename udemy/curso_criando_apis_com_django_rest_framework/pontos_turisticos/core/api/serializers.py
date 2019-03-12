from rest_framework.serializers import ModelSerializer

from atracoes.api.serializers import AtracaoSerializer
from comentarios.api.serializers import ComentarioSerializer
from core.models import PontoTuristico


class PontoTuristicoSerializer(ModelSerializer):
    atracoes = AtracaoSerializer(many=True, read_only=True)
    comentarios = ComentarioSerializer(many=True, read_only=True)

    class Meta:
        model = PontoTuristico
        fields = (
            "ponto_turistico_id",
            "nome",
            "descricao",
            "aprovado",
            "foto",
            "atracoes",
            "comentarios",
        )
