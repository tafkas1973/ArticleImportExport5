import { Component, OnInit } from '@angular/core';
import { Pagination } from '../../_models/pagination';
import { environment } from '../../../environments/environment';
import { Article } from '../../_models/article';
import { ArticleService } from '../../_services/article.service';

@Component({
  selector: 'app-article-cards',
  templateUrl: './article-cards.component.html',
  styleUrls: ['./article-cards.component.css']
})
export class ArticleCardsComponent implements OnInit {
  baseUrl = environment.apiUrl;
  articles: Array<Article>;
  pageTitle = "Articles";
  pageNumber = 1;
  pageSize = 4;
  pagination: Pagination;

  constructor(private articleService: ArticleService) { }

  ngOnInit(): void {
    this.loadArticles();
  }

  loadArticles() {
    this.articleService
      .getArticles(this.pageNumber, this.pageSize)
      .subscribe(response => {
        this.articles = response.result;
        this.pagination = response.pagination;
      })
  }

  pageChanged(event: any) {
    this.pageNumber = event.page;
    this.loadArticles();
  }
}
