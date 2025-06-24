import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KelasDetailsComponent } from './kelas-details.component';

describe('KelasDetailsComponent', () => {
  let component: KelasDetailsComponent;
  let fixture: ComponentFixture<KelasDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [KelasDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(KelasDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
