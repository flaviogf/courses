from django.shortcuts import render, get_object_or_404

from recipes.models import Recipe


def index(request):
    recipes = Recipe.objects.all()

    return render(request, 'index.html', {'recipes': recipes})


def show(request, pk):
    recipe = get_object_or_404(Recipe, pk=pk)

    return render(request, 'show.html', { 'recipe': recipe })
