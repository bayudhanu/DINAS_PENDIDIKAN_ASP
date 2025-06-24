import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddKelasComponent } from './add-kelas.component';

describe('AddKelasComponent', () => {
  let component: AddKelasComponent;
  let fixture: ComponentFixture<AddKelasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddKelasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddKelasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
