using System;
using System.Collections.Generic;
using System.Linq;

namespace Codifico.Senior.Core.Entities
{
    public class NavalBattleGames
    {
        private List<NavalBattleGame> _games;

        public NavalBattleGames()
        {
            _games = new List<NavalBattleGame>();
        }

        public NavalBattleGame AddPlayer(string Id)
        {
            Player newPlayer = new Player(Id);

            NavalBattleGame groupAlone = _games.FirstOrDefault(game => game.Player2 is null);

            if (groupAlone is null)
            {
                groupAlone = new NavalBattleGame();
                groupAlone.Player1 = newPlayer;
                _games.Add(groupAlone);
            }
            else
            {
                groupAlone.Player2 = newPlayer;
            }

            return groupAlone;
        }
    }
}
