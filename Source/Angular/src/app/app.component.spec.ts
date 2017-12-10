import { TestBed, async } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { NavalBattleComponent } from './naval-battle/naval-battle.component';
import { OpposingBoardComponent } from './opposing-board/opposing-board.component';
import { OwnBoardComponent } from './own-board/own-board.component';
import { NavalBattleService } from './services/naval-battle.service';
import { BoardComponent } from './board/board.component';

import 'rxjs/add/observable/of';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule
      ],
      declarations: [
        AppComponent,
        NavalBattleComponent,
        OpposingBoardComponent,
        OwnBoardComponent,
        BoardComponent
      ],
      providers: [
        NavalBattleService
      ]
    }).compileComponents();
  }));

  it('should create the app', async(() => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  }));
});
