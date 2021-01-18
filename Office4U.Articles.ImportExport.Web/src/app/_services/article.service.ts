import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Article } from '../_models/article';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  baseUrl = 'https://localhost:5001/';

  constructor(private http: HttpClient) { }

  getArticles(): Observable<Array<Article>> {
    return this.http.get<Array<Article>>(this.baseUrl + 'api/articles');
  }
}
