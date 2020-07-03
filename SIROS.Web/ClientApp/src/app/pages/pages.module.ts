import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PAGES_ROUTES } from './pages.routes';
import { SharedModule } from '../shared/shared.module';
import { PagesComponent } from './pages.component';
import { BlockUIModule } from 'ng-block-ui';
import { BlockTemplateCmpComponent } from '../block-template-cmp/block-template-cmp.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    PagesComponent,
    HomeComponent
  ],
  exports: [
    PagesComponent
  ],
  imports: [
    CommonModule,
    PAGES_ROUTES,
    SharedModule,
    FormsModule,
    BlockUIModule.forRoot({
      template: BlockTemplateCmpComponent
    })
  ],
  entryComponents: [ BlockTemplateCmpComponent ]
})
export class PagesModule { }
