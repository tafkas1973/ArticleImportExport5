import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from './_guards/auth.guard';
import { ArticleCardsComponent } from './articles/article-cards/article-cards.component';
import { ArticleDetailComponent } from './articles/article-detail/article-detail.component';
import { ArticleEditComponent } from './articles/article-edit/article-edit.component';
import { ArticlesComponent } from './articles/articles.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ExportComponent } from './export/export.component';
import { HomeComponent } from './home/home.component';
import { ImportComponent } from './import/import.component';
import { ManagementComponent } from './management/management.component';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'articles', component: ArticlesComponent },
      { path: 'articles/:id', component: ArticleDetailComponent },
      {
        path: 'article/edit/:id',
        component: ArticleEditComponent,
        canDeactivate: [PreventUnsavedChangesGuard]
      },
      { path: 'article-cards', component: ArticleCardsComponent },
      { path: 'import', component: ImportComponent },
      { path: 'export', component: ExportComponent },
      { path: 'management', component: ManagementComponent }
    ]
  },
  { path: 'errors', component: TestErrorsComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { path: '**', component: NotFoundComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
