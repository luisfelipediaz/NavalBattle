import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OpposingBoardComponent } from './opposing-board.component';
import { BoardComponent } from '../board/board.component';
import { NavalBattleService } from '../services/naval-battle.service';
import { Observable } from 'rxjs/Observable';

describe('OpposingBoardComponent', () => {
  let component: OpposingBoardComponent;
  let fixture: ComponentFixture<OpposingBoardComponent>;
  let service: NavalBattleService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        OpposingBoardComponent,
        BoardComponent
      ],
      providers: [
        NavalBattleService
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OpposingBoardComponent);
    component = fixture.componentInstance;

    component.game = {
      id: 'fakeGame',
      sizeInX: 8,
      sizeInY: 8,
      allPlayersOnline: false
    };

    service = fixture.debugElement.injector.get(NavalBattleService);

    spyOn(service, 'getMyTurn').and.callFake(() => Observable.of(false));
    spyOn(service, 'getMyMoves').and.callFake(() => Observable.of([]));

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
