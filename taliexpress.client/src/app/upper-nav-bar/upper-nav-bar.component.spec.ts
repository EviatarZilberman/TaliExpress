import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpperNavBarComponent } from './upper-nav-bar.component';

describe('UpperNavBarComponent', () => {
  let component: UpperNavBarComponent;
  let fixture: ComponentFixture<UpperNavBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpperNavBarComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpperNavBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
