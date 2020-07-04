import { Routes, RouterModule } from '@angular/router';
import { PagesComponent } from './pages.component';
import { HomeComponent } from './home/home.component';
import { MunicipalidadComponent } from './municipalidad/municipalidad.component';
import { OPGuard } from '../guards/op.guard';

const pagesRoutes: Routes = [
    {
        path: 'pages',
        component: PagesComponent,
        children: [
            { path: 'home', component: HomeComponent }
        ]
    },
    {
        path: 'promovilidad', component: PagesComponent, //canActivate: [OPGuard],
        children: [
            { path: 'municipalidad', component: MunicipalidadComponent },
        ]
    }
    // {
    //     path: 'OGTU',
        // component: PagesComponent,
        // children: [
        //     {path: 'Municipalidad', component: MunicipalidadComponent},
        //     ]
    // }
    // {
    //     path: 'OET',
        // component: PagesComponent,
        // children: [
        //     {path: 'Municipalidad', component: MunicipalidadComponent},
        //     ]
    // }
    // {
    //     path: 'OES',
        // component: PagesComponent,
        // children: [
        //     {path: 'Municipalidad', component: MunicipalidadComponent},
        //     ]
    // }
];

export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);
