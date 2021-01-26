import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { switchMap, tap } from 'rxjs/operators';

import { Article, ArticleForCreation } from '../../_models/article';
import { ArticleParams } from '../../_models/articleParams';
import { Pagination } from '../../_models/pagination';
import { ArticleService } from '../../_services/article.service';
import { ArticleCreateModalComponent } from '../article-create-modal/article-create-modal.component';

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
  validationErrors: Array<string> = [];
  modalRef: BsModalRef;
  forceLoad = false;

  constructor(
    private articleService: ArticleService,
    private router: Router,
    private modalService: BsModalService,
    private toastr: ToastrService
  ) {
    this.articleParams = this.articleService.getArticleParams();

    const navigation = this.router.getCurrentNavigation();
    this.forceLoad = navigation?.extras?.state?.forceLoad;
  }

  ngOnInit(): void {
    this.loadArticles(this.forceLoad);
  }

  onPageChanged(event: any) {
    this.articleParams.pageNumber = event.page;
    this.articleService.setArticleParams(this.articleParams);
    this.loadArticles(true);
  }

  onRowClick(articleId: number): void {
    this.router.navigateByUrl("/article/" + articleId.toString());
  }

  onLoadArticles(event: any): void {
    this.loadArticles();
  }

  onResetFilters(event: any): void {
    this.resetFilters();
  }

  onCreateArticle() {
    this.createArticle();
  }

  private loadArticles(forceLoad = false) {
    this.articleService.setArticleParams(this.articleParams);
    this.articleService
      .getArticles(this.articleParams, forceLoad)
      .subscribe(response => {
        this.articles = response.result;
        this.pagination = response.pagination;
      })
  }

  private resetFilters() {
    this.articleParams = this.articleService.resetArticleParams();
    this.loadArticles();
  }

  private createArticle() {
    this.validationErrors = [];
    var isCreated = false;
    const config = {
      class: 'modal-dialog-centered',
      ignoreBackdropClick: true,
      initialState: {
        validationErrors: this.validationErrors,
        isCreated: isCreated
      }
    }
    this.modalRef = this.modalService.show(ArticleCreateModalComponent, config);

    // we subscribe on the createActivityEvent that is send by the modal before closing
    // we do not want to nest observables, we want an observable chain 
    // use switchMap to create a new observable by taking another observable's data

    // TODO: unsubscribe
    this.modalRef.content.createArticleEvent
      .pipe(
        tap(() => console.log('createArticleEvent event fired in modal')),
        switchMap((newArticle: ArticleForCreation) => {
          return this.articleService.createArticle(newArticle);
        })
      )
      .subscribe(result => {
        // refresh activities
        this.onPageChanged({ page: 1 });
        this.toastr.success("Article was created");
      }, error => {
        Object.assign(this.validationErrors, error);
        this.toastr.error("Failed to create article");
      });
  }
}
