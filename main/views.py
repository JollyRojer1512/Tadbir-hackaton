from django.shortcuts import render

# Create your views here.

def index(request):
    return render(request, 'main/index.html')

def about(request):
    data = {
        'title': 'About us page',
        # 'values': ['Hello', 'Mothersucking', 'World']
    }
    return render(request, "main/about.html", data)

def contacts(request):
    data = {
        'title': 'Contacts page'
    }
    return render(request, "main/contacts.html", data)

def news(request):
    data = {
        'title': 'News home'
    }
    return render(request, "news/news_home.html", data)