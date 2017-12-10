import { Component, Input, OnInit } from '@angular/core';
import { NavalBattleGame } from '../app.model';
import { NavalBattleService } from '../services/naval-battle.service';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'app-opposing-board',
  templateUrl: './opposing-board.component.html',
  styleUrls: [ './opposing-board.component.scss' ]
})
export class OpposingBoardComponent implements OnInit {

  @Input() game: NavalBattleGame;

  myTurn: Boolean = false;

  constructor(private navalBattleService: NavalBattleService) { }

  ngOnInit() {
    this.navalBattleService.getMyTurn().subscribe((turn: boolean) => {
      this.myTurn = turn;
    });
  }

  public counter(count: number): any[] {
    const arr: number[] = [];
    for (let i = count - 1; i >= 0; i--) {
      arr.push(i);
    }
    return arr;
  }

  public getArrayLettersTo(countTo: number): string[] {
    return 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'.substring(0, countTo).split('');
  }

}
