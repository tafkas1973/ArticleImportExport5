import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Article } from '../../_models/article';
import { ArticleParams } from '../../_models/articleParams';
import { Pagination } from '../../_models/pagination';
import { ArticleService } from '../../_services/article.service';

@Component({
  selector: 'app-articles',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit {
  articles: Array<Article>;
  pageTitle = "Articles";
  pageNumber = 1;
  pageSize = 5;
  pagination: Pagination;
  articleParams: ArticleParams;
  columnTitles: Array<string> = ['Code', 'Supplier Id', 'Supplier Reference', 'Name', 'Unit', 'Purchase Price(€)'];
  rowCellPropertyNames: Array<string> = ['code', 'supplierId', 'supplierReference', 'name1', 'unit', 'purchasePrice'];

  constructor(
    private articleService: ArticleService,
    private router: Router) {
    this.articleParams = this.articleService.getArticleParams();
  }

  ngOnInit(): void {
    this.loadArticles();
  }

  loadArticles() {
    this.articleService.setArticleParams(this.articleParams);
    this.articleService
      .getArticles(this.articleParams)
      .subscribe(response => {
        this.articles = response.result;
        this.pagination = response.pagination;
      })
  }

  resetFilters() {
    this.articleParams = this.articleService.resetArticleParams();
    this.loadArticles();
  }

  pageChanged(event: any) {
    this.articleParams.pageNumber = event.page;
    this.articleService.setArticleParams(this.articleParams);
    this.loadArticles();
  }

  onRowClick(articleId: number) {
    this.router.navigateByUrl("/article/" + articleId.toString());
  }
}
