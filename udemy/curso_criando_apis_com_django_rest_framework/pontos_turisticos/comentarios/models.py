import uuid

from django.contrib.auth import get_user_model
from django.db import models

# Create your models here.


class Comentario(models.Model):
    comentario_id = models.UUIDField(
        primary_key=True, default=uuid.uuid4, editable=False
    )
    usuario = models.ForeignKey(get_user_model(), on_delete=models.CASCADE)
    comentario = models.TextField()
    data = models.DateTimeField(auto_now_add=True)
    aprovado = models.BooleanField(default=False)

    def __str__(self):
        return self.usuario.username
