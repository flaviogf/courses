import uuid

from django.contrib.auth import get_user_model
from django.db import models

# Create your models here.


class Avaliacao(models.Model):
    avaliacao_id = models.UUIDField(
        primary_key=True, default=uuid.uuid4, editable=False
    )
    usuario = models.ForeignKey(get_user_model(), on_delete=models.CASCADE)
    comentario = models.TextField(null=True, blank=True)
    nota = models.FloatField()
    data = models.DateTimeField(auto_now_add=True)

    def __str__(self):
        return f"{self.usuario.username} {self.nota}"
