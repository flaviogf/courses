from rest_framework.viewsets import ModelViewSet

from comentarios.api.serializers import ComentarioSerializer
from comentarios.models import Comentario


class ComentarioViewSet(ModelViewSet):
    serializer_class = ComentarioSerializer
    queryset = Comentario.objects.all()
