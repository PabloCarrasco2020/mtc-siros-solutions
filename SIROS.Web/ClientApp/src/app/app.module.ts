import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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
import { DigitOnlyDirective } from './directives/digit-only.directive';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    BlockTemplateCmpComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot({
      preventDuplicates: true,
      progressBar:true,
      enableHtml :  true,
      closeButton : true
    }), // ToastrModule added
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
