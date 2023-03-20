import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubtransactionsComponent } from './subtransactions.component';

describe('SubtransactionsComponent', () => {
  let component: SubtransactionsComponent;
  let fixture: ComponentFixture<SubtransactionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubtransactionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubtransactionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
