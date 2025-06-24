import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UploadSiswaComponent } from './upload-siswa.component';

describe('UploadSiswaComponent', () => {
  let component: UploadSiswaComponent;
  let fixture: ComponentFixture<UploadSiswaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UploadSiswaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UploadSiswaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
