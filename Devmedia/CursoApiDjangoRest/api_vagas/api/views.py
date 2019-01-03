from django.http import JsonResponse
from rest_framework import status
from rest_framework.response import Response
from rest_framework.views import APIView

from .models import Vaga
from .pagination import VagaPagination
from .serializer import VagaSerializer


class VagaView(APIView):

    def get(self, request):
        try:
            paginador = VagaPagination()
            resultado = paginador.paginate_queryset(Vaga.objects.all(), request)
            serializer = VagaSerializer(resultado, many=True)
            return paginador.get_paginated_response(serializer.data)
        except Exception as ex:
            print(ex)
            return JsonResponse({'mensagem': 'erro interno'}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)

    def post(self, request):
        try:
            serializer = VagaSerializer(data=request.data)
            if serializer.is_valid():
                serializer.save()
                return Response(serializer.data, status=status.HTTP_201_CREATED)
            return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)
        except Exception as ex:
            print(ex)
            return JsonResponse({'mensagem': 'erro interno'}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)


class VagaDetalheView(APIView):

    def delete(self, request, pk):
        try:
            if pk <= 0:
                return JsonResponse({'mensagem': 'id inválido'}, status=status.HTTP_400_BAD_REQUEST)
            vaga = Vaga.objects.get(pk=pk)
            vaga.delete()
            return Response(status=status.HTTP_204_NO_CONTENT)
        except Vaga.DoesNotExist:
            return JsonResponse({'mensagem': 'vaga nao encontrada'}, status=status.HTTP_404_NOT_FOUND)
        except Exception as ex:
            print(ex)
            return JsonResponse({'mensagem': 'erro interno'}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)

    def put(self, request, pk):
        try:
            if pk <= 0:
                return JsonResponse({'mensagem': 'id inválido'}, status=status.HTTP_400_BAD_REQUEST)
            vaga = Vaga.objects.get(pk=pk)
            serializer = VagaSerializer(vaga, data=request.data)
            if serializer.is_valid():
                serializer.save()
                return Response(serializer.data, status=status.HTTP_200_OK)
            return JsonResponse({'mensagem': 'erro interno'}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
        except Vaga.DoesNotExist:
            return JsonResponse({'mensagem': 'vaga nao encontrada'}, status=status.HTTP_404_NOT_FOUND)
        except Exception as ex:
            print(ex)
            return JsonResponse({'mensagem': 'erro interno'}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)

    def get(self, request, pk):
        try:
            if pk <= 0:
                return JsonResponse({'mensagem': 'id inválido'}, status=status.HTTP_400_BAD_REQUEST)
            vaga = Vaga.objects.get(pk=pk)
            serializer = VagaSerializer(vaga)
            return Response(serializer.data, status=status.HTTP_200_OK)
        except Vaga.DoesNotExist:
            return Response({'mesagem': 'vaga nao encontrada'}, status=status.HTTP_404_NOT_FOUND)
        except Exception as ex:
            print(ex)
            return JsonResponse({'mensagem': 'erro interno'}, status=status.HTTP_500_INTERNAL_SERVER_ERROR)
