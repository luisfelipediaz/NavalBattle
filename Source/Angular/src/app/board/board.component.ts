import { Component, OnInit, Input, TemplateRef, ContentChild } from '@angular/core';
import { NavalBattleGame } from '../app.model';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss']
})
export class BoardComponent implements OnInit {

  @Input() game: NavalBattleGame;
  @ContentChild(TemplateRef) itemTemplate: TemplateRef<any>;

  constructor() { }

  ngOnInit() {
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
