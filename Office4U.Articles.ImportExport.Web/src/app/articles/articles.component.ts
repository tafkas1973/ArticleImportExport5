import { Component, OnInit } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable';
import { Article } from '../_models/article';
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
