import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr-client';
import { NavalBattleService } from '../services/naval-battle.service';
import { Observable } from 'rxjs/Observable';
import { NavalBattleGame } from '../app.model';

@Component({
  selector: 'app-naval-battle',
  templateUrl: './naval-battle.component.html'
})
export class NavalBattleComponent implements OnInit {

  gameObservable: Observable<NavalBattleGame>;

  constructor(public navalBattleService: NavalBattleService) { }

  ngOnInit() {
    this.gameObservable = this.navalBattleService.initGame();
  }

}
