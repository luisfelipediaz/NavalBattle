using System;
using Codifico.Senior.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace Codifico.Senior.Test
{
    [TestClass]
    public class PlayerUnitTest
    {
        [TestMethod]
        public void ShouldEqualsReturnTrueWhenSendPlayer1String()
        {
            Player player = new Player("Player1");

            Boolean actual = player.Equals("Player1");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldEqualsReturnFalseWhenSendPlayer2String()
        {
            Player player = new Player("Player1");

            Boolean actual = player.Equals("Player2");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ShouldAddBoatReturnTrueWhenSendBoatThatDoesNotTruncate()
        {
            Player player = new Player("Player1");
            Boat boat1 = new Boat(new Point(1, 1), 3, Core.Direction.North);
            bool actual = player.AddBoat(boat1);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldAddBoatReturnTrueWhenSendBoatThatDoesTruncate()
        {
            Player player = new Player("Player1");
            Boat boat1 = new Boat(new Point(1, 1), 3, Core.Direction.North);
            player.AddBoat(boat1);

            Boat boat2 = new Boat(new Point(1, 2), 3, Core.Direction.East);
            bool actual = player.AddBoat(boat2);

            Assert.IsFalse(actual);
        }
    }
}
