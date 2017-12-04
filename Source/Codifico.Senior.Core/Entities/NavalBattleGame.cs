using System;
using System.Drawing;
using Codifico.Senior.Core.Tools;

namespace Codifico.Senior.Core.Entities
{
    public class NavalBattleGame
    {
        public string Id { get; }

        Player Player1 { get; set; }

        Player Player2 { get; set; }

        public Player Winner { get; set; }

        public NavalBattleGame()
        {
            Id = $"NavalBattle{DateTime.Now.Ticks}";
        }

        public Player GetPlayer(string idPlayer)
        {
            if (Player1.Equals(idPlayer)) return Player1;

            if (Player2.Equals(idPlayer)) return Player2;

            throw new ArgumentException("Player not exist");
        }

        public bool ExistIdPlayerInGame(string idPlayer)
        {
            return Player1.Equals(idPlayer) || Player2.Equals(idPlayer);
        }

        public void AssignPlayer1(Player player)
        {
            if (Player1 is null)
            {
                Player1 = player;
                ProcessPlayerBoats(Player1);
            }
            else
            {
                throw new System.ArgumentException("The player 1 already exists");
            }
        }

        public void AssignPlayer2(Player player)
        {
            if (Player2 is null)
            {
                Player2 = player;
                ProcessPlayerBoats(Player2);
            }
            else
            {
                throw new System.ArgumentException("The player 2 already exists");
            }
        }

        public bool Player2Missing()
        {
            return Player2 is null;
        }

        void ProcessPlayerBoats(Player player)
        {
            AddRandomBoat(player, 2);
            AddRandomBoat(player, 2);
            AddRandomBoat(player, 3);
            AddRandomBoat(player, 4);
        }

        void AddRandomBoat(Player player, int size)
        {
            bool overfow = true;
            bool added = true;
            do
            {
                Point initialPoint = Position.GetRandomPoint(Constants.MAX_X, Constants.MAX_Y);
                Direction direction = Position.GetRandomDirection();
                overfow = Position.Overflow(initialPoint, size, direction);
                if (overfow is false)
                {
                    Boat boatOneOfTwoSize = new Boat(initialPoint, size, direction);
                    added = player.AddBoat(boatOneOfTwoSize);
                }
            } while (overfow || (added is false));
        }
    }
}
