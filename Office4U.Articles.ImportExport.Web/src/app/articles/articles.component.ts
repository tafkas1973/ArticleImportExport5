import { Component, OnInit } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable';
import { Article } from '../_models/article';
import { ArticleService } from '../_services/article.service';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {
  //articles$: Observable<Array<Article>>;
  articles: Array<Article>;
  isLoading = true;
  ColumnMode = ColumnMode;
  moreRowsTooltip = 'Load more...';
  pageTitle = "Articles";

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
    //this.articles$ = this.articleService.getArticles();
    // for demo purposes
    this.articleService.getArticles()
      .subscribe(response => {
        setTimeout(() => {
          console.log(this.articles);
          this.articles = response;
          this.isLoading = false;
        }, 1000);
      });
  }
}
