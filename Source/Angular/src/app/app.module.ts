import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavalBattleComponent } from './naval-battle/naval-battle.component';
import { NavalBattleService } from './services/naval-battle.service';
import { OpposingBoardComponent } from './opposing-board/opposing-board.component';
import { OwnBoardComponent } from './own-board/own-board.component';
import { BoardComponent } from './board/board.component';


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
