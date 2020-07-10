import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { LoginGuard } from './guards/login.guard';

const appRoutes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent, canActivate: [LoginGuard] }
 ];

export const APP_ROUTES =  RouterModule.forRoot( appRoutes, {useHash: true});
