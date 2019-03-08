import uuid

from django.db import models

# Create your models here.


class Atracao(models.Model):
    atracao_id = models.UUIDField(primary_key=True, default=uuid.uuid4, editable=False)
    nome = models.CharField(max_length=250)
    descricao = models.TextField()
    horario_funcionamento = models.TextField()
    idade_minima = models.IntegerField()

    def __str__(self):
        return self.nome
