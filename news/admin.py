from django.contrib import admin
from django.db import models
from .models import Articles

# Register your models here.

class ArticlesAdmin(admin.ModelAdmin):
    list_display = ('id', 'title',)

admin.site.register(Articles, ArticlesAdmin)