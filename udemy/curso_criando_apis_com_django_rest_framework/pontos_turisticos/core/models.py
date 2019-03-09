import uuid

from django.db import models

from atracoes.models import Atracao
from avaliacoes.models import Avaliacao
from comentarios.models import Comentario
from enderecos.models import Endereco

# Create your models here.


class PontoTuristico(models.Model):
    ponto_turistico_id = models.UUIDField(
        primary_key=True, default=uuid.uuid4, editable=False
    )
    nome = models.CharField(max_length=250)
    descricao = models.TextField()
    aprovado = models.BooleanField(default=False)
    atracoes = models.ManyToManyField(Atracao)
    comentarios = models.ManyToManyField(Comentario)
    avaliacoes = models.ManyToManyField(Avaliacao)
    endereco = models.ForeignKey(
        Endereco, on_delete=models.CASCADE, null=True, blank=True
    )

    def __str__(self):
        return self.nome
