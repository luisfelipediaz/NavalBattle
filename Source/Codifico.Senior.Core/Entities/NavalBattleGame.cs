﻿using System;
namespace Codifico.Senior.Core.Entities
{
    public class NavalBattleGame
    {
        public Player Player1 { get; set; }

        public Player Player2 { get; set; }

        public Player Winner { get; set; }

        public Player GetPlayer(string player)
        {
            if (Player1.Equals(player))
            {
                return Player1;
            }

            if (Player2.Equals(player))
            {
                return Player2;
            }

            throw new ArgumentException("Player not exist");
        }
    }
}