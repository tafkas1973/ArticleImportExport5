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
  // rows: Array<any> = [];
  // columns: Array<any> = [];

  constructor(private articleService: ArticleService) { }
  rows = [];
  columns = [
    { prop: 'code' },
    { prop: 'supplierId' },
    { prop: 'supplierReference' },
    { prop: 'name1' },
    { prop: 'unit' },
    { prop: 'purchasePrice' }
  ];

  ngOnInit(): void {
    this.articles$ = this.articleService.getArticles();
  }
}
