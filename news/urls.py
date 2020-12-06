from django.urls import path
from . import views
from .models import Articles

urlpatterns = [
    path('', views.news_home, name='news_home'),
    path('create', views.create_article, name='create'),
    path('<int:pk>', views.NewsDetailView.as_view(model=Articles), name='news-detail'),
    path('<int:pk>/update', views.NewsUpdateView.as_view(model=Articles), name='news-update'),
    path('<int:pk>/delete', views.NewsDeleteView.as_view(model=Articles), name='news-delete'),
]