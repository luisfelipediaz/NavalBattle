import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnBoardComponent } from './own-board.component';
import { NavalBattleGame, Boat } from '../app.model';
import { NavalBattleService } from '../services/naval-battle.service';

describe('OwnBoardComponent', () => {
  let component: OwnBoardComponent;
  let fixture: ComponentFixture<OwnBoardComponent>;
  let compile;
  let game: NavalBattleGame

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [OwnBoardComponent],
      providers: [NavalBattleService]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OwnBoardComponent);
    component = fixture.componentInstance;

    const navalBattleService: NavalBattleService = fixture.debugElement.injector.get(NavalBattleService);

    spyOn(navalBattleService, 'getBoatsOfPlayer');

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

  it('should "counter" return a new array of 9 length', () => {
    const actual: any[] = component.counter(9)

    expect(actual.length).toBe(9);
  });

  it('should "getArrayLettersTo" return a new array of first 4 letters', () => {
    const expected: string[] = ['A','B','C','D'];
    const actual: string[] = component.getArrayLettersTo(4)

    expect(actual).toEqual(expected);
  });

  it('should assign class ".boat-cell" to the cells that belong to the array input of the boats', () => {
    const boats: Boat[] = [];
  });
});
