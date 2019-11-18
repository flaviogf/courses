from django.shortcuts import render


def index(request):
    return render(request, 'index.html')


def show(request):
    return render(request, 'show.html')
