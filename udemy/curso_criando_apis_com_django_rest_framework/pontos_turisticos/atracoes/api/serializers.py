from rest_framework.serializers import ModelSerializer

from atracoes.models import Atracao


class AtracaoSerializer(ModelSerializer):
    class Meta:
        model = Atracao
        fields = (
            "atracao_id",
            "nome",
            "descricao",
            "horario_funcionamento",
            "idade_minima",
            "foto",
        )
