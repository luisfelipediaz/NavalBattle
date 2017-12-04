using System;
using Codifico.Senior.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
