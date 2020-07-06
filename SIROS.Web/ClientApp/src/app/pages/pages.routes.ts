import { Routes, RouterModule } from '@angular/router';
import { PagesComponent } from './pages.component';
import { HomeComponent } from './home/home.component';
import { MunicipalidadComponent } from './municipalidad/municipalidad.component';
import { OPGuard } from '../guards/op.guard';
import { EstacionesServicioComponent } from './estaciones-servicio/estaciones-servicio.component';
import { PeriodosComponent } from './periodos/periodos.component';
import { CombustibleComponent } from './combustible/combustible.component';
import { ContratoESComponent } from './contrato-es/contrato-es.component';
import { SucursalESComponent } from './sucursal-es/sucursal-es.component';
import { RutasComponent } from './rutas/rutas.component';
import { EmpresasComponent } from './empresas/empresas.component';
import { VehiculoSucursalComponent } from './vehiculo-sucursal/vehiculo-sucursal.component';
import { RegistrarControlIEComponent } from './registrar-control-ie/registrar-control-ie.component';

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
            { path: 'estacionesServicio', component: EstacionesServicioComponent },
            { path: 'periodos', component: PeriodosComponent },
            { path: 'combustible', component: CombustibleComponent }
        ]
    },
    {
        path: 'OGTU', component: PagesComponent, //canActivate: [OGTUGuard],
        children: [
            { path: 'contratoES', component: ContratoESComponent },
            { path: 'sucursalES', component: SucursalESComponent },
            { path: 'rutas', component: RutasComponent },
            { path: 'empresas', component: EmpresasComponent },
            { path: 'vehiculoSucursal', component: VehiculoSucursalComponent },
            { path: 'registrarControlIE', component: RegistrarControlIEComponent }
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
