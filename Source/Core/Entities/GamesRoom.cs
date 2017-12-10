using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Entities
{
    public class GamesRoom
    {
        readonly List<NavalBattleGame> Games;

        public GamesRoom()
        {
            Games = new List<NavalBattleGame>();
        }

        public NavalBattleGame AddPlayer(string Id)
        {
            Player newPlayer = new Player(Id);

            NavalBattleGame groupAlone = Games.FirstOrDefault(game => game.GameIsIncomplete());

            if (groupAlone is null)
            {
                groupAlone = new NavalBattleGame();
                Games.Add(groupAlone);
            }

            groupAlone.AddPlayer(newPlayer);

            return groupAlone;
        }

        public Player GetPlayer(string IdPlayer)
        {
            return GetGameOfPlayer(IdPlayer)
                .GetPlayer(IdPlayer);
        }

        public NavalBattleGame GetGameOfPlayer(string IdPlayer)
        {
            return Games
                .FirstOrDefault(game => game.ExistIdPlayerInGame(IdPlayer));
        }
    }
}
