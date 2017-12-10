import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NavalBattleComponent } from './naval-battle/naval-battle.component';

const routes: Routes = [
  {
    path: 'navalBattle',
    component: NavalBattleComponent
  },
  {
    path: '',
    redirectTo: '/navalBattle',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
