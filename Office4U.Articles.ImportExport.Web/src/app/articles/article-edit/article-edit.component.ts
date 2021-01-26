import { Component, HostListener, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Article } from '../../_models/article';
import { ArticleService } from '../../_services/article.service';

@Component({
  selector: 'app-article-edit',
  templateUrl: './article-edit.component.html',
  styleUrls: ['./article-edit.component.css']
})
export class ArticleEditComponent implements OnInit, OnDestroy {
  @ViewChild('editForm') editForm: NgForm;
  notifier = new Subject();
  article: Article;
  pageTitle = "Article Edit";
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(
    private articleService: ArticleService,
    private route: ActivatedRoute,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.loadArticle();
  }

  loadArticle() {
    // TODO: unsubscribe
    this.articleService
      .getArticle(Number(this.route.snapshot.paramMap.get('id')))
      .pipe(takeUntil(this.notifier))
      .subscribe(article => {
        this.article = article
      });
  }

  updateArticle() {
    this.articleService
      .updateArticle(this.article)
      .pipe(takeUntil(this.notifier))
      .subscribe(() => {
        this.toastr.success('Article updated succesfully');
        this.editForm.reset(this.article);
      });
  }

  ngOnDestroy() {
    this.notifier.next();
    this.notifier.complete();
  }  
}
