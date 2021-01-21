import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { Article } from '../_models/article';
import { Paginatedresult } from '../_models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  baseUrl = environment.apiUrl;
  articles: Array<Article> = [];
  paginatedResult: Paginatedresult<Array<Article>> = new Paginatedresult<Array<Article>>();

  constructor(private http: HttpClient) { }

  getArticles(page?: number, itemsPerPage?: number) {
    let params = new HttpParams();

    if (page !== null && itemsPerPage !== null) {
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }

    // we also want the response body with the pagination info
    return this.http.get<Array<Article>>(this.baseUrl + 'articles', { observe: 'response', params })
      .pipe(
        map(response => {
          this.paginatedResult.result = response.body;
          if (response.headers.get('Pagination') !== null) {
            this.paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return this.paginatedResult;
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
