import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';

import { Article } from '../../_models/article';
import { ArticleService } from '../../_services/article.service';

@Component({
  selector: 'app-article-detail',
  templateUrl: './article-detail.component.html',
  styleUrls: ['./article-detail.component.css']
})
export class ArticleDetailComponent implements OnInit {
  article: Article;
  galleryOptions: Array<NgxGalleryOptions>;
  galleryImages: Array<NgxGalleryImage>;
  pageTitle = "Article Detail";
  
  constructor(
    private articleService: ArticleService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadArticle();

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ]
  }

  getImages(): Array<NgxGalleryImage> {
    const imageUrls = [];
    for (const photo of this.article.photos) {
      imageUrls.push({
        small: photo?.url,
        medium: photo?.url,
        big: photo?.url
      });
    }
    return imageUrls;
  }

  loadArticle() {
    this.articleService.getArticle((Number)(this.route.snapshot.paramMap.get('id')))
      .subscribe(article => {
        this.article = article
        this.galleryImages = this.getImages();
      });
  }
}
