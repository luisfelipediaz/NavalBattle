import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavalBattleComponent } from './naval-battle.component';
import { NavalBattleService } from '../services/naval-battle.service';
import { OwnBoardComponent } from '../own-board/own-board.component';
import { OpposingBoardComponent } from '../opposing-board/opposing-board.component';
import { BoardComponent } from '../board/board.component';

describe('NavalBattleComponent', () => {
  let component: NavalBattleComponent;
  let fixture: ComponentFixture<NavalBattleComponent>;
  let navalBattleService: NavalBattleService;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [
        NavalBattleComponent,
        OwnBoardComponent,
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
    fixture = TestBed.createComponent(NavalBattleComponent);
    component = fixture.componentInstance;

    navalBattleService = fixture.debugElement.injector.get(NavalBattleService);
    spyOn(navalBattleService, 'initGame');
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call the "initGame" for "NavalBattleService" in init of component', () => {
    expect(navalBattleService.initGame).toHaveBeenCalled();
  });
});
