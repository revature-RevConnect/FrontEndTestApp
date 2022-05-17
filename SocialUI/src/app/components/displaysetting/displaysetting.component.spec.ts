import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplaysettingComponent } from './displaysetting.component';

describe('DisplaysettingComponent', () => {
  let component: DisplaysettingComponent;
  let fixture: ComponentFixture<DisplaysettingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplaysettingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplaysettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
