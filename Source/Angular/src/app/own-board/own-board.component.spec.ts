import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnBoardComponent } from './own-board.component';
import { NavalBattleGame, Boat, Direction } from '../app.model';
import { NavalBattleService } from '../services/naval-battle.service';

describe('OwnBoardComponent', () => {
  let component: OwnBoardComponent;
  let fixture: ComponentFixture<OwnBoardComponent>;
  let compile;
  let game: NavalBattleGame;

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

    spyOn(navalBattleService, 'getBoatsOfPlayer').and.callFake(() => null);

    fixture.detectChanges();
  });

  beforeEach(() => {
    game = {
      id: 'fakeGame',
      sizeInX: 8,
      sizeInY: 8,
      allPlayersOnline: false
    };

    component.game = game;

    fixture.detectChanges();

    compile = fixture.debugElement.nativeElement;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
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
    const actual: any[] = component.counter(9);

    expect(actual.length).toBe(9);
  });

  it('should "getArrayLettersTo" return a new array of first 4 letters', () => {
    const expected: string[] = ['A', 'B', 'C', 'D'];
    const actual: string[] = component.getArrayLettersTo(4);

    expect(actual).toEqual(expected);
  });

  it('should "getClassOfCell" return "boat-cell boat-cell-east-west" when pass 2, 4', () => {
    component.boats = [
      {
        id: 'example',
        die: false,
        direction: Direction.East,
        points: [
          {
            x: 2,
            y: 4,
            beaten: false
          }
        ]
      }
    ];
    const actual: string = component.getClassOfCell(2, 4);

    expect(actual).toEqual('boat-cell boat-cell-east-west');
  });

  it('should "getClassOfCell" return "" when pass 4, 4', () => {
    component.boats = [];

    const actual: string = component.getClassOfCell(4, 4);

    expect(actual).toEqual('');
  });

  it('should "isHitABoat" return true when pass 2, 4', () => {
    component.boats = [
      {
        id: 'example',
        die: false,
        direction: Direction.East,
        points: [
          {
            x: 2,
            y: 4,
            beaten: true
          }
        ]
      }
    ];

    component.moves = [{ x: 2, y: 4 }];

    const actual = component.isHitABoat(2, 4);

    expect(actual).toBeTruthy();
  });
});
