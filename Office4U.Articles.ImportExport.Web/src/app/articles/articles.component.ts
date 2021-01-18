import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Article } from '../_models/article';
import { ArticleService } from '../_services/article.service';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {
  articles$: Observable<Array<Article>>;
  columns = [
    { prop: 'code', width: 100, flexGrow: true },
    { prop: 'supplierId', width: 100, flexGrow: true },
    { prop: 'supplierReference', width: 150, flexGrow: true },
    { prop: 'name1', width: 300, flexGrow: true },
    {
      prop: 'unit',
      width: 50,
      flexGrow: true,
      headerClass: 'text-right',
      cellClass: 'text-right pr-1'
    },
    {
      prop: 'purchasePrice',
      flexGrow: true,
      headerClass: 'text-right',
      cellClass: 'text-right'
    }
  ];
  rows = [];

  constructor(private articleService: ArticleService) { }

  ngOnInit(): void {
    this.articles$ = this.articleService.getArticles();
  }
}
