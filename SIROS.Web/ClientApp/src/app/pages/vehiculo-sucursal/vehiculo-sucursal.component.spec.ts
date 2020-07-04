import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VehiculoSucursalComponent } from './vehiculo-sucursal.component';

describe('VehiculoSucursalComponent', () => {
  let component: VehiculoSucursalComponent;
  let fixture: ComponentFixture<VehiculoSucursalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VehiculoSucursalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VehiculoSucursalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
