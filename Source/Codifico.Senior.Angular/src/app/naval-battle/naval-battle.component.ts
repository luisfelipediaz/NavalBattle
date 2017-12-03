import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr-client';
import { NavalBattleService } from '../services/naval-battle.service';

@Component({
  selector: 'app-naval-battle',
  templateUrl: './naval-battle.component.html'
})
export class NavalBattleComponent implements OnInit {

  message: string;

  constructor(public navalBattleService: NavalBattleService) { }

  ngOnInit() {
    this.navalBattleService.onMoveRival().subscribe((data) => {
      alert(data);
    });
  }

  public sendMessage(): void {
    this.navalBattleService.sendMove(this.message);
  }

}
