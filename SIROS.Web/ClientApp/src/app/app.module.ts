import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { BlockTemplateCmpComponent } from './block-template-cmp/block-template-cmp.component';
import { RouterModule } from '@angular/router';
import { APP_ROUTES } from './app.routes';
import { PagesModule } from './pages/pages.module';
import { SharedModule } from './shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BlockUIModule } from 'ng-block-ui';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    BlockTemplateCmpComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    APP_ROUTES,
    PagesModule,
    SharedModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    BlockUIModule.forRoot({
      template: BlockTemplateCmpComponent
    })
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [ BlockTemplateCmpComponent ]
})
export class AppModule { }
