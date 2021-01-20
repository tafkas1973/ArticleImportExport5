import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { environment } from '../../environments/environment';
import { Article } from '../_models/article';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getArticles() {
    return this.http.get<Array<Article>>(this.baseUrl + 'articles');
  }

  getArticle(id: string) {
    return this.http.get<Article>(this.baseUrl + 'articles/' + id.toString());
  }
}
