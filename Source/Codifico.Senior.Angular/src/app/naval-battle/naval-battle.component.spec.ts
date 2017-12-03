import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NavalBattleComponent } from './naval-battle.component';

describe('NavalBattleComponent', () => {
  let component: NavalBattleComponent;
  let fixture: ComponentFixture<NavalBattleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NavalBattleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NavalBattleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
