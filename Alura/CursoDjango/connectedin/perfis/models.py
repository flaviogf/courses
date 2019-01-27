from django.db import models


# Create your models here
class Perfil(models.Model):
    nome = models.CharField('nome', max_length=250)
    telefone = models.CharField('telefone', max_length=250)
    empresa = models.CharField('empresa', max_length=250)
    criado_em = models.DateTimeField('criado_em', auto_now_add=True)
    atualizado_em = models.DateTimeField('atualizado_em', auto_now=True)

    def convida(self, perfil):
        Convite.objects.create(solicitante=self, convidado=perfil)

    class Meta:
        verbose_name = 'Perfil'
        verbose_name_plural = 'Perfis'
        ordering = ['nome']


class Convite(models.Model):
    solicitante = models.ForeignKey(Perfil,
                                    on_delete=models.CASCADE,
                                    related_name='solicitacoes')
    convidado = models.ForeignKey(Perfil,
                                  on_delete=models.CASCADE,
                                  related_name='convites')

    class Meta:
        verbose_name = 'Convite'
        verbose_name_plural = 'Convites'
