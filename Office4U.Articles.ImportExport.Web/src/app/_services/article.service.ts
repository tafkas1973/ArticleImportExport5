import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { Article } from '../_models/article';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  baseUrl = environment.apiUrl;
  articles: Array<Article> = [];

  constructor(private http: HttpClient) { }

  getArticles() {
    if (this.articles.length > 0) return of(this.articles);
    return this.http.get<Array<Article>>(this.baseUrl + 'articles')
      .pipe(
        map(articles => {
          this.articles = articles;
          return articles;
        })
      );
  }

  getArticle(id: number) {
    const article = this.articles.find(a => a.id === id);
    if (article !== undefined) return of(article);
    return this.http.get<Article>(this.baseUrl + 'articles/' + id.toString());
  }

  updateArticle(article: Article) {
    return this.http
      .put(this.baseUrl + 'articles', article)
      .pipe(
        map(() => {
          const index = this.articles.indexOf(article);
          this.articles[index] = article;
        })
      );
  }
}
