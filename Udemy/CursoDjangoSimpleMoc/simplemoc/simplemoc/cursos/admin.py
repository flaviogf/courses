from django.contrib import admin

from .models import Curso


class CursoAdmin(admin.ModelAdmin):
    list_display = ('nome', 'descricao', 'criacao', 'atualizacao')
    list_filter = ('criacao',)
    search_fields = ('nome', 'descricao')
    prepopulated_fields = {'slug': ('nome',)}


admin.site.register(Curso, CursoAdmin)
