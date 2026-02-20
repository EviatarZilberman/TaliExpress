import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ScreenMessageComponent } from './screenMessage.component';

describe('ScreenMessageComponent', () => {
  let component: ScreenMessageComponent;
  let fixture: ComponentFixture<ScreenMessageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ScreenMessageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ScreenMessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
