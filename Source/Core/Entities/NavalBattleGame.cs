using System;
using System.Drawing;
using Core.Tools;
using System.Linq;

namespace Core.Entities
{
    public class NavalBattleGame
    {
        public string Id { get; }
        public int SizeInX { get; }
        public int SizeInY { get; }
        public bool AllPlayersOnline { get; set; }
        public Player Winner { get; set; }
        public Player[] Players { get; set; }

        public NavalBattleGame()
        {
            Id = $"NavalBattle{DateTime.Now.Ticks}";
            SizeInX = Constants.MAX_X + 1;
            SizeInY = Constants.MAX_Y + 1;
            Players = new Player[2];
            AllPlayersOnline = false;
        }

        public Player GetPlayer(string idPlayer)
        {
            Player playerFound = Players.FirstOrDefault(player => player?.Id == idPlayer);

            if (playerFound is null)
                throw new ArgumentException("Player not exist");

            return playerFound;
        }

        public bool ExistIdPlayerInGame(string idPlayer)
        {
            return Players.Any(player => player?.Id == idPlayer);
        }

        public void AddPlayer(Player player)
        {
            if (Players[0] is null)
            {
                Players[0] = player;
            }
            else if (Players[1] is null)
            {
                Players[1] = player;
                AllPlayersOnline = true;
            }
            else
            {
                throw new RankException("This game is full");
            }

            ProcessPlayerBoats(player);
        }

        public bool GameIsIncomplete()
        {
            return Players.Any(player => player is null);
        }

        public Player GetOpponent(string IdCurrentPlayer)
        {
            return Players.First(player => !player.Id.Equals(IdCurrentPlayer));
        }

        public Boolean SendMoveToPlayer(Player playerFrom, Player playerTo, PointBoat move) {
            if(playerTo.HitMarket(new Point(move.X, move.Y))) {
                move.Beaten = true;
            }

            playerFrom.Moves.Add(move);

            return move.Beaten;
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
