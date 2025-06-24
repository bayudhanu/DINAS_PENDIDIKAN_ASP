import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SiswaListComponent } from './siswa-list.component';

describe('SiswaListComponent', () => {
  let component: SiswaListComponent;
  let fixture: ComponentFixture<SiswaListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SiswaListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SiswaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
