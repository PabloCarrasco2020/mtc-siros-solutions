import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RutasEmpresaComponent } from './rutas-empresa.component';

describe('RutasEmpresaComponent', () => {
  let component: RutasEmpresaComponent;
  let fixture: ComponentFixture<RutasEmpresaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RutasEmpresaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RutasEmpresaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
