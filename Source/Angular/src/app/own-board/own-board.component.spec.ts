import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnBoardComponent } from './own-board.component';
import { Direction } from '../app.model';
import { NavalBattleService } from '../services/naval-battle.service';
import { BoardComponent } from '../board/board.component';
import { of } from 'rxjs';

describe('OwnBoardComponent', () => {
  let component: OwnBoardComponent;
  let fixture: ComponentFixture<OwnBoardComponent>;


  beforeEach(async () => {
    TestBed.configureTestingModule({
      declarations: [
        OwnBoardComponent,
        BoardComponent
      ],
      providers: [NavalBattleService]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OwnBoardComponent);
    component = fixture.componentInstance;

    component.game = {
      id: 'fakeGame',
      sizeInX: 8,
      sizeInY: 8,
      allPlayersOnline: false
    };

    const navalBattleService: NavalBattleService = fixture.debugElement.injector.get(NavalBattleService);

    spyOn(navalBattleService, 'getBoatsOfPlayer')
      .and.callFake(() => of([]));

    spyOn(navalBattleService, 'getOppositeMoves')
      .and.callFake(() => of([]));

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
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
