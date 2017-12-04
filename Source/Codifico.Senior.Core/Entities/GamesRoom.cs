using System;
using System.Collections.Generic;
using System.Linq;

namespace Codifico.Senior.Core.Entities
{
    public class GamesRoom
    {
        private List<NavalBattleGame> _games;

        public GamesRoom()
        {
            _games = new List<NavalBattleGame>();
        }

        public NavalBattleGame AddPlayer(string Id)
        {
            Player newPlayer = new Player(Id);

            NavalBattleGame groupAlone = _games.FirstOrDefault(game => game.Player2Missing());

            if (groupAlone is null)
            {
                groupAlone = new NavalBattleGame();
                groupAlone.AssignPlayer1(newPlayer);
                _games.Add(groupAlone);
            }
            else
            {
                groupAlone.AssignPlayer2(newPlayer);
            }

            return groupAlone;
        }
    }
}
