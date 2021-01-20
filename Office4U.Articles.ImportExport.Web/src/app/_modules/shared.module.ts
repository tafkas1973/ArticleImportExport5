import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    NgxDatatableModule,
    TabsModule.forRoot(),
    NgxGalleryModule
  ],
  exports: [
    BsDropdownModule,
    ToastrModule,
    NgxDatatableModule,
    TabsModule,
    NgxGalleryModule
  ]
})
export class SharedModule { }
