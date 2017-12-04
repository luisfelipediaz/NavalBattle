using System;
using System.Collections.Generic;
using System.Linq;

namespace Codifico.Senior.Core.Entities
{
    public class GamesRoom
    {
        List<NavalBattleGame> Games;

        public GamesRoom()
        {
            Games = new List<NavalBattleGame>();
        }

        public NavalBattleGame AddPlayer(string Id)
        {
            Player newPlayer = new Player(Id);

            NavalBattleGame groupAlone = Games.FirstOrDefault(game => game.Player2Missing());

            if (groupAlone is null)
            {
                groupAlone = new NavalBattleGame();
                groupAlone.AssignPlayer1(newPlayer);
                Games.Add(groupAlone);
            }
            else
            {
                groupAlone.AssignPlayer2(newPlayer);
            }

            return groupAlone;
        }

        public NavalBattleGame GetGameOfIdPlayer(string IdPlayer)
        {
            return Games.FirstOrDefault(game => game.ExistIdPlayerInGame(IdPlayer));
        }
    }
}
