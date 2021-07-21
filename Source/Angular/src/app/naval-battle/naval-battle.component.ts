import { Component, OnInit } from '@angular/core';
import { NavalBattleService } from '../services/naval-battle.service';
import { NavalBattleGame } from '../app.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-naval-battle',
  templateUrl: './naval-battle.component.html'
})
export class NavalBattleComponent implements OnInit {

  gameObservable: Observable<NavalBattleGame> | undefined;

  constructor(public navalBattleService: NavalBattleService) { }

  ngOnInit() {
    this.gameObservable = this.navalBattleService.initGame();
  }

}
