import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadKelasComponent } from './upload-kelas.component';

describe('UploadKelasComponent', () => {
  let component: UploadKelasComponent;
  let fixture: ComponentFixture<UploadKelasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UploadKelasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UploadKelasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
