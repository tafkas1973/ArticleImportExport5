import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    NgxDatatableModule    
  ],
  exports: [
    BsDropdownModule,
    ToastrModule,
    NgxDatatableModule
  ]
})
export class SharedModule { }
