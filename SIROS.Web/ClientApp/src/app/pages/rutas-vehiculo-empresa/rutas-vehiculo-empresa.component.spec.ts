import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RutasVehiculoEmpresaComponent } from './rutas-vehiculo-empresa.component';

describe('RutasVehiculoEmpresaComponent', () => {
  let component: RutasVehiculoEmpresaComponent;
  let fixture: ComponentFixture<RutasVehiculoEmpresaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RutasVehiculoEmpresaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RutasVehiculoEmpresaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
