from django.conf import settings
from django.conf.urls.static import static
from django.contrib import admin
from django.urls import path, include

urlpatterns = [
    path('', include('simplemoc.core.urls', namespace='core')),
    path('conta/', include('simplemoc.conta.urls', namespace='conta')),
    path('cursos/', include('simplemoc.cursos.urls', namespace='cursos')),
    path('admin/', admin.site.urls)
]

urlpatterns += static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)
