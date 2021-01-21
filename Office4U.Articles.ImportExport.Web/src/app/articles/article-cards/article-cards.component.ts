import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { environment } from '../../../environments/environment';
import { Article } from '../../_models/article';
import { ArticleService } from '../../_services/article.service';

@Component({
  selector: 'app-article-cards',
  templateUrl: './article-cards.component.html',
  styleUrls: ['./article-cards.component.css']
})
export class ArticleCardsComponent implements OnInit, OnDestroy {
  baseUrl = environment.apiUrl;
  articles$: Observable<Array<Article>>;
  pageTitle = "Articles";
  private notifier = new Subject();

  constructor(private articleService: ArticleService) { }

  ngOnInit(): void {
    this.articles$ = this.articleService.getArticles();
  }

  ngOnDestroy() {
    this.notifier.next();
    this.notifier.complete();
  }
}
