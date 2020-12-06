from django.shortcuts import render, redirect
from .models import Articles
from .forms import ArticlesForm
from django.views.generic import DetailView, UpdateView, DeleteView

# Create your views here.

def news_home(request):
    news = Articles.objects.all()   
    data = {
        'title': 'Articles',
        'news':  news,
    }
    return render(request,  'news/news_home.html', data)

class NewsDetailView(DetailView):
    model = Articles()
    template_name = 'news/details_view.html'
    context_object_name = 'article'

class NewsUpdateView(UpdateView):
    model = Articles
    template_name = 'news/create.html'
    form_class = ArticlesForm

class NewsDeleteView(UpdateView):
    model = Articles
    success_url = '/news'
    template_name = 'news/news-delete.html'
    fields = []
    
    
def create_article(request):
    error = ''
    if request.method == "POST":
            form = ArticlesForm(request.POST)
            if form.is_valid():
                form.save()
                return redirect('news_home')
            else:
                error: 'Invalid form'


    form = ArticlesForm()
    data = {
        'title': 'Create',
        'form': form,
        'error': error
    }
    return render(request,  'news/create.html', data)