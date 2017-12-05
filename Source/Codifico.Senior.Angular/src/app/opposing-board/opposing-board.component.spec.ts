import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpposingBoardComponent } from './opposing-board.component';

describe('OpposingBoardComponent', () => {
  let component: OpposingBoardComponent;
  let fixture: ComponentFixture<OpposingBoardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OpposingBoardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpposingBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
