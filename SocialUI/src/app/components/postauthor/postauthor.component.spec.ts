import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostauthorComponent } from './postauthor.component';

describe('PostauthorComponent', () => {
  let component: PostauthorComponent;
  let fixture: ComponentFixture<PostauthorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostauthorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostauthorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
