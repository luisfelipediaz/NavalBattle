import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NavalBattleComponent } from './naval-battle/naval-battle.component';
import { NavalBattleService } from './services/naval-battle.service';


@NgModule({
  declarations: [
    AppComponent,
    NavalBattleComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [NavalBattleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
