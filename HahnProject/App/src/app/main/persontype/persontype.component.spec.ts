import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersontypeComponent } from './persontype.component';

describe('PersontypeComponent', () => {
  let component: PersontypeComponent;
  let fixture: ComponentFixture<PersontypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersontypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PersontypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
