import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { BoardComponent } from './board.component';

describe('BoardComponent', () => {
  let component: BoardComponent;
  let fixture: ComponentFixture<BoardComponent>;
  let compile: any;

  beforeEach((async () => {
    TestBed.configureTestingModule({
      declarations: [BoardComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BoardComponent);
    component = fixture.componentInstance;

    component.game = {
      id: 'fakeGame',
      sizeInX: 8,
      sizeInY: 8,
      allPlayersOnline: false
    };

    fixture.detectChanges();

    compile = fixture.debugElement.nativeElement;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should "counter" return a new array of 9 length', () => {
    const actual: any[] = component.counter(9);

    expect(actual.length).toBe(9);
  });

  it('should "getArrayLettersTo" return a new array of first 4 letters', () => {
    const expected: string[] = ['A', 'B', 'C', 'D'];
    const actual: string[] = component.getArrayLettersTo(4);

    expect(actual).toEqual(expected);
  });

  it('should bind a table', () => {
    expect(compile.querySelector('table')).toBeTruthy();
  });

  it('should bind table with 9 rows, configured in input "game"', () => {
    expect(compile.querySelectorAll('table tr').length).toEqual((component.game?.sizeInY ?? 0) + 1);
  });

  it('should bind table with 9 tds per row, configured in input "game"', () => {
    expect(compile.querySelector('table tr').querySelectorAll('td').length).toEqual((component.game?.sizeInY ?? 0) + 1);
  });
});
