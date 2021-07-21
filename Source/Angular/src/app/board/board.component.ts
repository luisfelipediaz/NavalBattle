import { Component, Input, TemplateRef, ContentChild } from '@angular/core';
import { NavalBattleGame } from '../app.model';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss']
})
export class BoardComponent {
  @Input() game: NavalBattleGame | null = null;
  @ContentChild(TemplateRef) itemTemplate: TemplateRef<any> |null = null;

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
