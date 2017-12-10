import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { HubConnection } from '@aspnet/signalr-client';
import { environment } from '../../environments/environment';
import { NavalBattleGame, Boat } from '../app.model';

@Injectable()
export class NavalBattleService {

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
    this.hubConnection.on('onAssignGame', (game: NavalBattleGame) => {
      this.startGame.next(game);
    });

    this.hubConnection.on('getBoatsOfPlayer', (boats: any) => {
      this.boatsOfPlayer.next(boats);
    });

    this.hubConnection.on('onGameFull', (game: NavalBattleGame) => {
      this.startGame.next(game);
    });
  }

  getBoatsOfPlayer(): Observable<Boat[]> {
    this.hubConnection.invoke('GetBoatsOfPlayer').then((boats: Boat[]) => {
      this.boatsOfPlayer.next(boats);
    });

    return this.boatsOfPlayer;
  }
}
