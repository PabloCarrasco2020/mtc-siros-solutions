import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrarControlIEComponent } from './registrar-control-ie.component';

describe('RegistrarControlIEComponent', () => {
  let component: RegistrarControlIEComponent;
  let fixture: ComponentFixture<RegistrarControlIEComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistrarControlIEComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrarControlIEComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
