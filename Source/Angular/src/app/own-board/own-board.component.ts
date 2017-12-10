import { Component, OnInit, OnChanges, Input, SimpleChanges } from '@angular/core';
import { NavalBattleGame } from '../app.model';
import { NavalBattleService } from '../services/naval-battle.service';

@Component({
  selector: 'app-own-board',
  templateUrl: './own-board.component.html',
  styleUrls: ['./own-board.component.scss']
})
export class OwnBoardComponent implements OnInit, OnChanges {
  @Input() game: NavalBattleGame;

  constructor(private navalBattleService: NavalBattleService) { }

  ngOnInit() {
    this.navalBattleService.getBoatsOfPlayer();
  }

  ngOnChanges(changes: SimpleChanges): void {

  }

  public counter(count: number): any[] {
    return Array(count);
  }

  public getArrayLettersTo(countTo: number): string[] {
    return 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'.substring(0, countTo).split('');
  }

}
