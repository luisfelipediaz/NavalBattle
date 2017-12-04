using System;
using Codifico.Senior.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codifico.Senior.Test
{
    [TestClass]
    public class NavalBattleGamesTestUnit
    {
        [TestMethod]
        public void ShouldReturnNavalBattleGameOnAddPlayerOneAndTwo()
        {
            NavalBattleGames games = new NavalBattleGames();
            NavalBattleGame gamePlayer1 = games.AddPlayer("player1");
            NavalBattleGame gamePlayer2 = games.AddPlayer("player2");

            Assert.IsFalse(gamePlayer1 is null);
            Assert.IsFalse(gamePlayer2 is null);

            Assert.AreEqual(gamePlayer1, gamePlayer2);
        }

        [TestMethod]
        public void ShouldCreatedNewNavaBattleOfExistsTheyAreFull()
        {
            NavalBattleGames games = new NavalBattleGames();
            games.AddPlayer("player1");
            NavalBattleGame gamePlayer2 = games.AddPlayer("player2");
            NavalBattleGame gamePlayer3 = games.AddPlayer("player3");
            Assert.AreNotEqual(gamePlayer2, gamePlayer3);
        }
    }
}
