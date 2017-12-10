import { TestBed, inject } from '@angular/core/testing';

import { NavalBattleService } from './naval-battle.service';

describe('NavalBattleService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NavalBattleService]
    });
  });

  it('should be created', inject([NavalBattleService], (service: NavalBattleService) => {
    expect(service).toBeTruthy();
  }));
});
