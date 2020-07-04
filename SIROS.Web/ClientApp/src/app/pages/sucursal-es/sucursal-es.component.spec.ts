import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SucursalESComponent } from './sucursal-es.component';

describe('SucursalESComponent', () => {
  let component: SucursalESComponent;
  let fixture: ComponentFixture<SucursalESComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SucursalESComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SucursalESComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
