using Microsoft.VisualStudio.TestTools.UnitTesting;
using Codifico.Senior.Core.Entities;

namespace Codifico.Senior.Test
{
    [TestClass]
    public class NavalBattleGameTestUnit
    {
        [TestMethod]
        public void ShouldCreateNewGuidInConstructor()
        {
            NavalBattleGame game = new NavalBattleGame();
            Assert.IsFalse(game.Id is null);
        }

        [TestMethod]
        public void ShouldReturnThePlayer1WhenSendPlayerAny()
        {
            Player expected = new Player("PlayerAny");
            NavalBattleGame game = new NavalBattleGame
            {
                Player1 = new Player("PlayerAny"),
                Player2 = new Player("Player1")
            };

            Player actualPlayer = game.GetPlayer("PlayerAny");

            Assert.AreEqual(expected.Id, actualPlayer.Id);
        }

        [TestMethod]
        public void ShouldReturnThePlayer2WhenSendPlayerAny()
        {
            Player expected = new Player("PlayerAny");
            NavalBattleGame game = new NavalBattleGame
            {
                Player1 = new Player("Player1"),
                Player2 = new Player("PlayerAny")
            };

            Player actualPlayer = game.GetPlayer("PlayerAny");

            Assert.AreEqual(expected.Id, actualPlayer.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ShouldThrowExceptionWhenSendPlayerError()
        {
            NavalBattleGame game = new NavalBattleGame
            {
                Player1 = new Player("Player1"),
                Player2 = new Player("PlayerAny")
            };
            game.GetPlayer("PlayerError");
        }
    }
}
