import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnBoardComponent } from './own-board.component';
import { NavalBattleGame } from '../app.model';

describe('OwnBoardComponent', () => {
  let component: OwnBoardComponent;
  let fixture: ComponentFixture<OwnBoardComponent>;
  let compile;
  let game: NavalBattleGame

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [OwnBoardComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OwnBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  beforeEach(() => {
    game = {
      id: 'fakeGame',
      sizeInX: 8,
      sizeInY: 8
    };

    component.game = game;

    fixture.detectChanges();

    compile = fixture.debugElement.nativeElement;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should not render table while game is not defined', () => {
    delete component.game;
    fixture.detectChanges();

    expect(compile.querySelector('table')).toBeFalsy();
  });

  it('should bind a table', () => {
    expect(compile.querySelector('table')).toBeTruthy();
  });

  it('should bind table with 9 rows, configured in input "game"', () => {
    expect(compile.querySelectorAll('table tr').length).toEqual(game.sizeInY + 1);
  });

  it('should bind table with 9 tds per row, configured in input "game"', () => {
    expect(compile.querySelector('table tr').querySelectorAll('td').length).toEqual(game.sizeInY + 1);
  });

  it('should assign class ".boat-cell" to the cells that belong to the array input of the boats', () => {
    const boats: Boat[] = [];
  });
});
