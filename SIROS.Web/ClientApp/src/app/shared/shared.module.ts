import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TablaComponent } from './tabla/tabla.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FooterComponent } from './footer/footer.component';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';

@NgModule({
  declarations: [
    TablaComponent,
    NavbarComponent,
    SidebarComponent,
    FooterComponent,
    BreadcrumbComponent
  ],
  exports: [
    TablaComponent,
    NavbarComponent,
    SidebarComponent,
    FooterComponent,
    BreadcrumbComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    FormsModule,
  ]
})
export class SharedModule { }
