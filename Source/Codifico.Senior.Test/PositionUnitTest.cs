using System;
using System.Collections.Generic;
using System.Drawing;
using Codifico.Senior.Core.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codifico.Senior.Test
{
    [TestClass]
    public class PositionUnitTest
    {
        [TestMethod]
        public void ShouldCreateAPositionWith3Points()
        {
            var position = Position.InitPointsNotMarked(new Point(1, 2), new Point(1, 4));

            Assert.AreEqual(3, position.Count);
        }


    }
}
