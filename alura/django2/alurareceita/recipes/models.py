from django.db import models


class Recipe(models.Model):
    name = models.CharField(max_length=100)
    ingredients = models.TextField(max_length=500)
    method = models.TextField(max_length=500)
    time = models.IntegerField()
    production = models.TextField(max_length=500)
    category = models.CharField(max_length=100)
    created_at = models.DateTimeField(auto_now_add=True, editable=False)

    def __str__(self):
        return self.name
