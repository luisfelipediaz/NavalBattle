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
            NavalBattleGame game = new NavalBattleGame();
            game.AssignPlayer1(new Player("PlayerAny"));
            game.AssignPlayer2(new Player("Player1"));

            Player actualPlayer = game.GetPlayer("PlayerAny");

            Assert.AreEqual(expected.Id, actualPlayer.Id);
        }

        [TestMethod]
        public void ShouldReturnThePlayer2WhenSendPlayerAny()
        {
            Player expected = new Player("PlayerAny");
            NavalBattleGame game = new NavalBattleGame();
            game.AssignPlayer1(new Player("Player1"));
            game.AssignPlayer2(new Player("PlayerAny"));

            Player actualPlayer = game.GetPlayer("PlayerAny");

            Assert.AreEqual(expected.Id, actualPlayer.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ShouldThrowExceptionWhenSendPlayerError()
        {
            NavalBattleGame game = new NavalBattleGame();
            game.AssignPlayer1(new Player("Player1"));
            game.AssignPlayer2(new Player("PlayerAny"));
            game.GetPlayer("PlayerError");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ShouldPlayer2MissingReturnTrueWhilePlayer2IsNotDefined()
        {
            NavalBattleGame game = new NavalBattleGame();
            game.AssignPlayer1(new Player("Player1"));
            Assert.IsTrue(game.Player2Missing());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ShouldPlayer2MissingReturnTrueWhenPlayer2IsDefined()
        {
            NavalBattleGame game = new NavalBattleGame();
            game.AssignPlayer1(new Player("Player1"));
            game.AssignPlayer2(new Player("Player2"));
            Assert.IsFalse(game.Player2Missing());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ShouldNotPermiteOverridePlayer1()
        {
            NavalBattleGame game = new NavalBattleGame();
            game.AssignPlayer1(new Player("Player1"));
            game.AssignPlayer1(new Player("PlayerAny"));
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ShouldNotPermiteOverridePlayer2()
        {
            NavalBattleGame game = new NavalBattleGame();
            game.AssignPlayer2(new Player("Player2"));
            game.AssignPlayer2(new Player("PlayerAny"));
        }
    }
}
