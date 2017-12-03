import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Subject } from 'rxjs/Subject';
import { HubConnection } from '@aspnet/signalr-client';

@Injectable()
export class NavalBattleService {

  private movesOfRival: Subject<any> = new Subject<any>();
  private hubConnection: HubConnection;

  constructor() {
    this.initSignalR();
  }

  private initSignalR() {
    this.hubConnection = new HubConnection('http://localhost:5000/navalBattle');
    this.createHubs();
    this.startSignalR();
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

    this.hubConnection.on('onAssignGroup', (groupName: string) => {
      alert(groupName);
    });
  }

  onMoveRival(): Observable<any> {
    return this.movesOfRival;
  }

  sendMove(data: string): void {
    this.hubConnection.invoke('Send', data);
  }
}
