import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { HubConnection } from '@aspnet/signalr-client';
import { environment } from '../../environments/environment';
import { NavalBattleGame, Boat, PointInBoat } from '../app.model';

@Injectable()
export class NavalBattleService {

  private startGame: Subject<NavalBattleGame> = new Subject<NavalBattleGame>();
  private turns: Subject<boolean> = new Subject<boolean>();
  private boatsOfPlayer: Subject<Boat[]> = new Subject<Boat[]>();
  private myMoves: Subject<PointInBoat[]> = new Subject<PointInBoat[]>();
  private oppositeMoves: Subject<PointInBoat[]> = new Subject<PointInBoat[]>();

  private hubConnection: HubConnection;

  constructor() {

  }

  public initGame(): Observable<NavalBattleGame> {
    this.hubConnection = new HubConnection(environment.urlNavalSignalR);
    this.createHubs();
    this.startSignalR();
    return this.startGame;
  }

  public getBoatsOfPlayer(): Observable<Boat[]> {
    this.hubConnection.invoke('GetBoatsOfPlayer').then((boats: Boat[]) => {
      this.boatsOfPlayer.next(boats);
    });

    return this.boatsOfPlayer;
  }

  public getMyTurn(): Observable<boolean> {
    return this.turns;
  }

  public getOppositeMoves(): Observable<PointInBoat[]> {
    return this.oppositeMoves;
  }

  public getMyMoves(): Observable<PointInBoat[]> {
    return this.myMoves;
  }

  public sendMove(x: number, y: number): void {
    this.hubConnection.send('SendMove', x, y);
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

    this.hubConnection.on('changeTurn', (itsMyTurn: boolean) => {
      this.turns.next(itsMyTurn);
    });

    this.hubConnection.on('onMyMovesChange', (moves: PointInBoat[]) => {
      this.myMoves.next(moves);
    });

    this.hubConnection.on('onOppositeMovesChange', (moves: PointInBoat[]) => {
      this.oppositeMoves.next(moves);
    });
  }

}
