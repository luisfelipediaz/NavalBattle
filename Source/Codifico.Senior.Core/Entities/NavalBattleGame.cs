using System;
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
                throw new System.ArgumentException("The player 1 already exists");
            }
        }

        private void ProcessPlayerBoats(Player player)
        {
            //TODO
        }

        public bool Player2Missing()
        {
            return Player2 is null;
        }
    }
}
