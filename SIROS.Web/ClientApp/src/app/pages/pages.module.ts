import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PAGES_ROUTES } from './pages.routes';
import { SharedModule } from '../shared/shared.module';
import { PagesComponent } from './pages.component';
import { BlockUIModule } from 'ng-block-ui';
import { BlockTemplateCmpComponent } from '../block-template-cmp/block-template-cmp.component';
import { HomeComponent } from './home/home.component';
import { MunicipalidadComponent } from './municipalidad/municipalidad.component';
import { EstacionesServicioComponent } from './estaciones-servicio/estaciones-servicio.component';
import { PeriodosComponent } from './periodos/periodos.component';
import { CombustibleComponent } from './combustible/combustible.component';
import { ContratoESComponent } from './contrato-es/contrato-es.component';
import { SucursalESComponent } from './sucursal-es/sucursal-es.component';
import { RutasComponent } from './rutas/rutas.component';
import { EmpresasComponent } from './empresas/empresas.component';
import { VehiculoSucursalComponent } from './vehiculo-sucursal/vehiculo-sucursal.component';
import { RegistrarControlIEComponent } from './registrar-control-ie/registrar-control-ie.component';
import { SessionInterceptor } from '../utils/session.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { OperadorEsComponent } from './operador-es/operador-es.component';
import { DigitOnlyDirective } from '../directives/digit-only.directive';
import { OperadorEmpresaComponent } from './operador-empresa/operador-empresa.component';
import { RutasEmpresaComponent } from './rutas-empresa/rutas-empresa.component';
import { ReporteDiarioComponent } from './reporte-diario/reporte-diario.component';
// DIRECTIVES
import { UpperCaseDirective } from '../directives/upper-case.directive';
import { LowerCaseDirective } from '../directives/lower-case.directive';
import { VehiculoRutaEmpresaComponent } from './vehiculo-ruta-empresa/vehiculo-ruta-empresa.component';
import { FormularioOgtuComponent } from './formulario-ogtu/formulario-ogtu.component';

@NgModule({
  declarations: [
    PagesComponent,
    HomeComponent,
    MunicipalidadComponent,
    EstacionesServicioComponent,
    PeriodosComponent,
    CombustibleComponent,
    ContratoESComponent,
    SucursalESComponent,
    RutasComponent,
    EmpresasComponent,
    VehiculoSucursalComponent,
    RegistrarControlIEComponent,
    OperadorEsComponent,
    DigitOnlyDirective,
    OperadorEmpresaComponent,
    RutasEmpresaComponent,
    ReporteDiarioComponent,
    UpperCaseDirective,
    LowerCaseDirective,
    VehiculoRutaEmpresaComponent,
    FormularioOgtuComponent
  ],
  exports: [
    PagesComponent
  ],
  imports: [
    CommonModule,
    PAGES_ROUTES,
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
    BlockUIModule.forRoot({
      template: BlockTemplateCmpComponent
    })
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: SessionInterceptor, multi: true }
  ],
  entryComponents: [ BlockTemplateCmpComponent ]
})
export class PagesModule { }
