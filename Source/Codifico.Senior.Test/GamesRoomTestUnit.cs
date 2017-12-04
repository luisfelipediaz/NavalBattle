using System;
using Codifico.Senior.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codifico.Senior.Test
{
    [TestClass]
    public class GamesRoomTestUnit
    {
        [TestMethod]
        public void ShouldReturnNavalBattleGameOnAddPlayerOneAndTwo()
        {
            GamesRoom games = new GamesRoom();
            NavalBattleGame gamePlayer1 = games.AddPlayer("player1");
            NavalBattleGame gamePlayer2 = games.AddPlayer("player2");

            Assert.IsFalse(gamePlayer1 is null);
            Assert.IsFalse(gamePlayer2 is null);

            Assert.AreEqual(gamePlayer1, gamePlayer2);
        }

        [TestMethod]
        public void ShouldCreatedNewNavaBattleOfExistsTheyAreFull()
        {
            GamesRoom games = new GamesRoom();
            games.AddPlayer("player1");
            NavalBattleGame gamePlayer2 = games.AddPlayer("player2");
            NavalBattleGame gamePlayer3 = games.AddPlayer("player3");
            Assert.AreNotEqual(gamePlayer2, gamePlayer3);
        }

        [TestMethod]
        public void ShouldGetGameOfIdPlayerReturnNullWhenNoExistPlayerInGames()
        {
            GamesRoom games = new GamesRoom();
            //games.AddPlayer("player1");

            NavalBattleGame gameOfPlayer1 = games.GetGameOfIdPlayer("player1");

            Assert.IsNull(gameOfPlayer1);
        }

        [TestMethod]
        public void ShouldGetGameOfIdPlayerReturnGameWhenExistPlayerInGames()
        {
            GamesRoom games = new GamesRoom();
            games.AddPlayer("player1");

            NavalBattleGame gameOfPlayer1 = games.GetGameOfIdPlayer("player1");

            Assert.IsNotNull(gameOfPlayer1);
        }
    }
}
