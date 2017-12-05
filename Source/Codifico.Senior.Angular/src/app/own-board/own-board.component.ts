import { Component, OnInit, OnChanges, Input, SimpleChanges } from '@angular/core';
import { NavalBattleGame } from '../app.model';

@Component({
  selector: 'app-own-board',
  templateUrl: './own-board.component.html',
  styleUrls: ['./own-board.component.scss']
})
export class OwnBoardComponent implements OnInit, OnChanges {
  @Input() game: NavalBattleGame;

  constructor() { }

  ngOnInit() {
  }
  
  ngOnChanges(changes: SimpleChanges): void {
    
  }

  public counter(count: number): any[] {
    return Array(count);
  }

}
