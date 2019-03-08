from django.db import models

# Create your models here.


class Endereco(models.Model):
    linha1 = models.CharField(max_length=250)
    linha2 = models.CharField(max_length=250, null=True, blank=True)
    cidade = models.CharField(max_length=250)
    estado = models.CharField(max_length=250)
    pais = models.CharField(max_length=250)
    latitude = models.IntegerField(null=True, blank=True)
    longitude = models.IntegerField(null=True, blank=True)

    def __str__(self):
        return f"{self.linha1} {self.linha2 if self.linha2 else ''}"
