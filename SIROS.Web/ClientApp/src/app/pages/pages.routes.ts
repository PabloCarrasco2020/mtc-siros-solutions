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
import { OGTUGuard } from '../guards/ogtu.guard';
import { InGuard } from '../guards/in.guard';
import { OperadorEsComponent } from './operador-es/operador-es.component';
import { OperadorEmpresaComponent } from './operador-empresa/operador-empresa.component';
import { RutasEmpresaComponent } from './rutas-empresa/rutas-empresa.component';
import { RutasVehiculoEmpresaComponent } from './rutas-vehiculo-empresa/rutas-vehiculo-empresa.component';
import { OESGuard } from '../guards/oes.guard';
import { ReporteDiarioComponent } from './reporte-diario/reporte-diario.component';
const pagesRoutes: Routes = [
    {
        path: 'pages',
        component: PagesComponent,
        children: [
            { path: 'home', component: HomeComponent }
        ], canActivate: [InGuard]
    },
    {
        path: 'promovilidad', component: PagesComponent, canActivate: [OPGuard],
        children: [
            { path: 'municipalidad', component: MunicipalidadComponent },
            { path: 'estacionesServicio', component: EstacionesServicioComponent },
            { path: 'periodos', component: PeriodosComponent },
            { path: 'combustible', component: CombustibleComponent }
        ]
    },
    {
        path: 'OGTU', component: PagesComponent, canActivate: [OGTUGuard],
        children: [
            { path: 'contratoES', component: ContratoESComponent },
            { path: 'sucursalES', component: SucursalESComponent },
            { path: 'operadorES/:id/:sucursal', component: OperadorEsComponent },
            { path: 'rutas', component: RutasComponent },
            { path: 'empresas', component: EmpresasComponent },
            { path: 'operadorEmpresa/:nIdEmpresa/:sEmpresa', component: OperadorEmpresaComponent },
            { path: 'rutasEmpresa/:nIdEmpresa/:sEmpresa', component: RutasEmpresaComponent },
            { path: 'rutasVehiculoEmpresa', component: RutasVehiculoEmpresaComponent },
            { path: 'vehiculoSucursal', component: VehiculoSucursalComponent },
            { path: 'registrarControlIE', component: RegistrarControlIEComponent }
        ]
    },
    {
        path: 'OES', component: PagesComponent, canActivate: [OESGuard],
        children: [
            //{ path: 'formulario', component: formularioComponent },
            { path: 'reporteDiario', component: ReporteDiarioComponent }
            
        ]
    }

];

export const PAGES_ROUTES = RouterModule.forChild(pagesRoutes);
