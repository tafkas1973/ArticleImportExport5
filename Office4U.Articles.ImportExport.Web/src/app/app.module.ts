import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';

import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { SharedModule } from './_modules/shared.module';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { ImportComponent } from './import/import.component';
import { ExportComponent } from './export/export.component';
import { ManagementComponent } from './management/management.component';
import { ArticleListComponent } from './articles/article-list/article-list.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { ArticleDetailComponent } from './articles/article-detail/article-detail.component';
import { ArticleEditComponent } from './articles/article-edit/article-edit.component';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { ArticleListFilterComponent } from './articles/article-list-filter/article-list-filter.component';
import { O4uLabelInputComponent } from './components/o4u-label-input/o4u-label-input.component';
import { O4uTableComponent } from './components/o4u-table/o4u-table.component';
import { O4uTitleComponent } from './components/o4u-title/o4u-title.component';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { RolesModalComponent } from './admin/roles-modal/roles-modal.component';
import { HasRoleDirective } from './_directives/has-role.directive';
import { ArticleCreateModalComponent } from './articles/article-create-modal/article-create-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    ImportComponent,
    ExportComponent,
    ManagementComponent,
    ArticleListComponent,
    ArticleDetailComponent,
    ArticleEditComponent,
    ArticleListFilterComponent,
    AdminPanelComponent,
    HasRoleDirective,
    UserManagementComponent,
    RolesModalComponent,
    O4uLabelInputComponent,
    O4uTableComponent,
    O4uTitleComponent,
    ArticleCreateModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
