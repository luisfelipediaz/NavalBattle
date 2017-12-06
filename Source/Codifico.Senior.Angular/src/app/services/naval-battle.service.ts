import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { HubConnection } from '@aspnet/signalr-client';
import { environment } from '../../environments/environment';
import { NavalBattleGame, Boat } from '../app.model';

@Injectable()
export class NavalBattleService {

  private movesOfRival: Subject<any> = new Subject<any>();
  private startGame: Subject<NavalBattleGame> = new Subject<NavalBattleGame>();
  private boatsOfPlayer: Subject<Boat[]> = new Subject<Boat[]>();
  private hubConnection: HubConnection;

  constructor() {

  }

  public initGame(): Observable<NavalBattleGame> {
    this.hubConnection = new HubConnection(environment.urlNavalSignalR);
    this.createHubs();
    this.startSignalR();
    return this.startGame;
  }

  private startSignalR() {
    this.hubConnection.start()
      .then(() => console.log('Hub connection started'))
      .catch(err => console.log(err));
  }

  private createHubs() {
    this.hubConnection.on('Send', (data: any) => {
      this.movesOfRival.next(data);
    });

    this.hubConnection.on('onAssignGame', (game: NavalBattleGame) => {
      this.startGame.next(game);
    });

    this.hubConnection.on('getBoatsOfPlayer', (boats: any) => {
      debugger;
      this.boatsOfPlayer.next(boats);
    });
  }

  onMoveRival(): Observable<any> {
    return this.movesOfRival;
  }

  sendMove(data: string): void {
    this.hubConnection.invoke('Send', data);
  }

  getBoatsOfPlayer() {
    this.hubConnection.invoke('GetBoatsOfPlayer').then((...args) => { debugger; });

  }
}
