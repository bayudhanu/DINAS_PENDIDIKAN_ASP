import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditKelasComponent } from './edit-kelas.component';

describe('EditKelasComponent', () => {
  let component: EditKelasComponent;
  let fixture: ComponentFixture<EditKelasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditKelasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditKelasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
