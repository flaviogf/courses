from django.db import models


class Artigo(models.Model):
    titulo = models.CharField(max_length=50)
    conteudo = models.TextField()
    criado_em = models.DateTimeField(auto_now_add=True)
    atualizado_em = models.DateTimeField(auto_now=True)
