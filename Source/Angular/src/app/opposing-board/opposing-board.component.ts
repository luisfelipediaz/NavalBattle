import { Component, Input, OnInit } from '@angular/core';
import { NavalBattleGame, PointInBoat } from '../app.model';
import { NavalBattleService } from '../services/naval-battle.service';

@Component({
  selector: 'app-opposing-board',
  templateUrl: './opposing-board.component.html',
  styleUrls: ['./opposing-board.component.scss']
})
export class OpposingBoardComponent implements OnInit {
  @Input() game: NavalBattleGame | null = null;

  myTurn: Boolean = false;

  myMoves: PointInBoat[] = [];

  constructor(private navalBattleService: NavalBattleService) { }

  ngOnInit() {
    this.navalBattleService.getMyTurn().subscribe((turn: boolean) => {
      this.myTurn = turn;
    });

    this.navalBattleService.getMyMoves().subscribe((moves: PointInBoat[]) => {
      this.myMoves = moves;
    });
  }

  isCellBeaten(x: number, y: number): boolean {
    return this.myMoves.some((move: PointInBoat) => move.x === x && move.y === y && move.beaten);
  }

  isNotHitCell(x: number, y: number): boolean {
    return this.myMoves.some((move: PointInBoat) => move.x === x && move.y === y && !move.beaten);
  }

  public sendMove(indexX: number, indexY: number): void {
    this.navalBattleService.sendMove(indexX, indexY);
  }

}
