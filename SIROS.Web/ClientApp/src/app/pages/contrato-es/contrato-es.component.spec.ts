import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContratoESComponent } from './contrato-es.component';

describe('ContratoESComponent', () => {
  let component: ContratoESComponent;
  let fixture: ComponentFixture<ContratoESComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContratoESComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContratoESComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
