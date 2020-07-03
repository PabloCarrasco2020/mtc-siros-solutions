import { Routes, RouterModule } from '@angular/router';
import { PagesComponent } from './pages.component';
import { HomeComponent } from './home/home.component';
import { MunicipalidadComponent } from './municipalidad/municipalidad.component';

const pagesRoutes: Routes = [
    {
        path: 'pages',
        component: PagesComponent,
        children: [
            { path: 'home', component: HomeComponent },
            { path: 'municipalidad', component: MunicipalidadComponent }
        ]
    }
    // {
    //     path: 'OP',
        // component: PagesComponent,
        // children: [
        //     {path: 'Municipalidad', component: MunicipalidadComponent},
        //     ]
    // }
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
