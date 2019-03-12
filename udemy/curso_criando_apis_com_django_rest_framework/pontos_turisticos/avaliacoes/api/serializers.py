from rest_framework.serializers import ModelSerializer, StringRelatedField

from avaliacoes.models import Avaliacao


class AvaliacaoSerializer(ModelSerializer):
    class Meta:
        model = Avaliacao
        fields = ("avaliacao_id", "usuario", "comentario", "nota", "data")
