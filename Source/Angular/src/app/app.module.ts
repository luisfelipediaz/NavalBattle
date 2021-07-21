import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BoardComponent } from './board/board.component';
import { NavalBattleComponent } from './naval-battle/naval-battle.component';
import { OpposingBoardComponent } from './opposing-board/opposing-board.component';
import { OwnBoardComponent } from './own-board/own-board.component';
import { NavalBattleService } from './services/naval-battle.service';

@NgModule({
  declarations: [
    AppComponent,
    NavalBattleComponent,
    OpposingBoardComponent,
    OwnBoardComponent,
    BoardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [NavalBattleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
