import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SiswaDetailsComponent } from './siswa-details.component';

describe('SiswaDetailsComponent', () => {
  let component: SiswaDetailsComponent;
  let fixture: ComponentFixture<SiswaDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SiswaDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SiswaDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
