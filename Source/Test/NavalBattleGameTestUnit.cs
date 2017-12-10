using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Entities;
using System.Linq;

namespace Test
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
            game.AddPlayer(new Player("PlayerAny"));
            game.AddPlayer(new Player("Player1"));

            Player actualPlayer = game.GetPlayer("PlayerAny");

            Assert.AreEqual(expected.Id, actualPlayer.Id);
        }

        [TestMethod]
        public void ShouldReturnThePlayer2WhenSendPlayerAny()
        {
            Player expected = new Player("PlayerAny");
            NavalBattleGame game = new NavalBattleGame();
            game.AddPlayer(new Player("Player1"));
            game.AddPlayer(new Player("PlayerAny"));

            Player actualPlayer = game.GetPlayer("PlayerAny");

            Assert.AreEqual(expected.Id, actualPlayer.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void ShouldThrowExceptionWhenSendPlayerError()
        {
            NavalBattleGame game = new NavalBattleGame();
            game.AddPlayer(new Player("Player1"));
            game.AddPlayer(new Player("PlayerAny"));
            game.GetPlayer("PlayerError");
        }

        [TestMethod]
        public void ShouldPlayer2MissingReturnTrueWhilePlayer2IsNotDefined()
        {
            NavalBattleGame game = new NavalBattleGame();
            game.AddPlayer(new Player("Player1"));
            Assert.IsTrue(game.GameIsIncomplete());
        }

        [TestMethod]
        public void ShouldPlayer2MissingReturnFalseWhenPlayer2IsDefined()
        {
            NavalBattleGame game = new NavalBattleGame();
            game.AddPlayer(new Player("Player1"));
            game.AddPlayer(new Player("Player2"));
            Assert.IsFalse(game.GameIsIncomplete());
        }

        [TestMethod]
        [ExpectedException(typeof(System.RankException))]
        public void ShouldNotPermiteAddMoreOfTwoPlayers()
        {
            NavalBattleGame game = new NavalBattleGame();
            game.AddPlayer(new Player("Player1"));
            game.AddPlayer(new Player("Player2"));
            game.AddPlayer(new Player("PlayerAny"));
        }

        [TestMethod]
        public void ShouldCreateTwoBoatsOfTwoSize()
        {
            NavalBattleGame game = new NavalBattleGame();
            game.AddPlayer(new Player("Player1"));
            Player player = game.GetPlayer("Player1");
            int countOfTwoSize = player.Boats.Count(boat => boat.Size == 2);
            Assert.AreEqual(2, countOfTwoSize);
        }

        [TestMethod]
        public void ShouldCreateOnBoatsOfThreeSize()
        {
            NavalBattleGame game = new NavalBattleGame();
            game.AddPlayer(new Player("Player1"));
            Player player = game.GetPlayer("Player1");
            int countOfThreeSize = player.Boats.Count(boat => boat.Size == 3);
            Assert.AreEqual(1, countOfThreeSize);
        }

        [TestMethod]
        public void ShouldCreateOnBoatsOfFourSize()
        {
            NavalBattleGame game = new NavalBattleGame();
            game.AddPlayer(new Player("Player1"));
            Player player = game.GetPlayer("Player1");
            int countOfFourSize = player.Boats.Count(boat => boat.Size == 4);
            Assert.AreEqual(1, countOfFourSize);
        }
    }
}
