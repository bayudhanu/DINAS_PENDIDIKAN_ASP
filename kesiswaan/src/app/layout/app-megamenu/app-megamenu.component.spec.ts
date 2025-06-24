import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppMegamenuComponent } from './app-megamenu.component';

describe('AppMegamenuComponent', () => {
  let component: AppMegamenuComponent;
  let fixture: ComponentFixture<AppMegamenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AppMegamenuComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AppMegamenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
