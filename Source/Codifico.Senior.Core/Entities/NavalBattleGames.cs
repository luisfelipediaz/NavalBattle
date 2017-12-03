using System;
using System.Collections.Generic;
using System.Linq;

namespace Codifico.Senior.Core.Entities
{
    public class NavalBattleGames
    {
        public List<NavalBattleGame> Games { get; set; }

        public NavalBattleGame AddPlayer(string Id)
        {
            NavalBattleGame groupAlone = Games.FirstOrDefault(game => game.Player2 is null);

            if (groupAlone.Player1 is null)
            {
                groupAlone.Player1 = new Player { Id = Id };
                Games.Add(groupAlone);
            }
            else
            {
                groupAlone.Player2 = new Player { Id = Id };
            }

            return groupAlone;
        }
    }
}
