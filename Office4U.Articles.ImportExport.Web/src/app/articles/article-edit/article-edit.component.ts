import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Article } from '../../_models/article';
import { ArticleService } from '../../_services/article.service';

@Component({
  selector: 'app-article-edit',
  templateUrl: './article-edit.component.html',
  styleUrls: ['./article-edit.component.css']
})
export class ArticleEditComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
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
      .subscribe(article => {
        this.article = article
      });
  }

  updateArticle() {
    this.articleService
      .updateArticle(this.article)
      .subscribe(() => {
        this.toastr.success('Article updated succesfully');
        this.editForm.reset(this.article);
      });
  }
}
