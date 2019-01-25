from django.db import models


# Create your models here.
class Perfil:
    def __init__(self, perfil_id=0, nome='', telefone='', empresa=''):
        self.perfil_id = perfil_id
        self.nome = nome
        self.telefone = telefone
        self.empresa = empresa
