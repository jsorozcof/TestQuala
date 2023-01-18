import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarEditarSucursalComponent } from './agregar-editar-sucursal.component';

describe('AgregarEditarSucursalComponent', () => {
  let component: AgregarEditarSucursalComponent;
  let fixture: ComponentFixture<AgregarEditarSucursalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregarEditarSucursalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgregarEditarSucursalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
