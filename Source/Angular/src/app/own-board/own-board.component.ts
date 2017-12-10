import { Component, OnChanges, Input, SimpleChanges, OnInit } from '@angular/core';
import { NavalBattleGame, Boat, Point, PointInBoat, Direction } from '../app.model';
import { NavalBattleService } from '../services/naval-battle.service';

@Component({
  selector: 'app-own-board',
  templateUrl: './own-board.component.html',
  styleUrls: ['./own-board.component.scss']
})
export class OwnBoardComponent implements OnInit {

  @Input() game: NavalBattleGame;

  moves: Point[] = [];

  boats: Boat[] = [];

  constructor(private navalBattleService: NavalBattleService) { }

  ngOnInit(): void {
    this.navalBattleService.getBoatsOfPlayer().subscribe(
      (boats: Boat[]) => this.boats = boats
    );

    this.navalBattleService.getOppositeMoves().subscribe(
      (moves: Point[]) => this.moves = moves
    );
  }

  isHitABoat(x: number, y: number): boolean {
    return this.moves.some((move: { x: number, y: number }) => {
      return move.x === x && move.y === y;
    });
  }

  getClassOfCell(x: number, y: number): string {
    const classOfCell: string[] = [];

    const boatFind: Boat = this.boats.find((boat: Boat) =>
      boat.points.some((point: PointInBoat) => point.x === x && point.y === y)
    );

    if (!!boatFind) {
      classOfCell.push('boat-cell');

      if (boatFind.direction === Direction.North || boatFind.direction === Direction.South) {
        classOfCell.push('boat-cell-north-south');
      } else {
        classOfCell.push('boat-cell-east-west');
      }
    }

    return classOfCell.join(' ');
  }

}
