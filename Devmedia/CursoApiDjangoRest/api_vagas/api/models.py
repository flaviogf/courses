from django.db import models

TIPO_CONTRATO = (
    ('CLT', 'Pessoa Fisica'),
    ('PJ', 'Pessoa Jurídica')
)


class Vaga(models.Model):
    titulo = models.CharField(max_length=25)
    descricao = models.TextField(max_length=100)
    tipo_contrato = models.CharField(choices=TIPO_CONTRATO, max_length=3)
    salario = models.FloatField()
    status = models.BooleanField(default=1)
