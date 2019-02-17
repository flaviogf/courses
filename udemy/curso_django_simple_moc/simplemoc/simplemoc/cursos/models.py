from django.db import models
from django.urls import reverse


class CursoManager(models.Manager):

    def busca(self, query):
        return super().get_queryset().filter(
            models.Q(descricao__icontains=query) |
            models.Q(nome__icontains=query)
        )


class Curso(models.Model):
    nome = models.CharField('Nome', max_length=50)
    slug = models.SlugField('Slug')
    descricao = models.TextField('Descrição', blank=True)
    data_inicio = models.DateField('Data de início', null=True, blank=True)
    imagem = models.ImageField('Imagem', upload_to='cursos/imagem', null=True, blank=True)
    criacao = models.DateTimeField('Criação', auto_now_add=True)
    atualizacao = models.DateTimeField('Atualização', auto_now=True)

    objects = CursoManager()

    def get_absolute_url(self):
        return reverse('cursos:detalhe', kwargs={'slug': self.slug})

    def __str__(self):
        return f'{self.nome} - {self.descricao}'
