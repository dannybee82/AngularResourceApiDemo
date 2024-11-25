import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateOrUpdateBookComponent } from './create-or-update-book.component';

describe('CreateOrUpdateBookComponent', () => {
  let component: CreateOrUpdateBookComponent;
  let fixture: ComponentFixture<CreateOrUpdateBookComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateOrUpdateBookComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateOrUpdateBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
