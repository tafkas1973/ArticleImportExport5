import { Component, OnInit } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable';
import { Article } from '../_models/article';
import { ArticleParams } from '../_models/articleParams';
import { Pagination } from '../_models/pagination';
import { ArticleService } from '../_services/article.service';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {
  articles: Array<Article>;
  ColumnMode = ColumnMode;
  pageTitle = "Articles";
  pageNumber = 1;
  pageSize = 5;
  pagination: Pagination;
  articleParams: ArticleParams;

  columns = [
    { prop: 'code', width: 100, flexGrow: true, sortable: false },
    { prop: 'supplierId', width: 100, flexGrow: true, sortable: false },
    { prop: 'supplierReference', width: 150, flexGrow: true, sortable: false },
    { prop: 'name1', width: 300, flexGrow: true, sortable: false },
    {
      prop: 'unit',
      width: 50,
      flexGrow: true,
      headerClass: 'text-right',
      cellClass: 'text-right pr-1',
      sortable: false
    },
    {
      prop: 'purchasePrice',
      flexGrow: true,
      headerClass: 'text-right',
      cellClass: 'text-right',
      sortable: false
    }
  ];
  rows = [];

  constructor(
    private articleService: ArticleService) {
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
}
