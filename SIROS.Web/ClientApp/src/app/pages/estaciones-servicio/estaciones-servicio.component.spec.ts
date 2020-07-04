import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EstacionesServicioComponent } from './estaciones-servicio.component';

describe('EstacionesServicioComponent', () => {
  let component: EstacionesServicioComponent;
  let fixture: ComponentFixture<EstacionesServicioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EstacionesServicioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EstacionesServicioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
