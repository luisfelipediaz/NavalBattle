using System;
using System.Collections.Generic;
using System.Drawing;
using Core;
using Core.Entities;
using Core.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class PositionUnitTest
    {
        [TestMethod]
        public void ShouldInitPointsNotMarkedReturnAPositionWith3Points()
        {
            List<PointBoat> position = Position.InitPointsNotMarked(new Point(1, 2), 3, Core.Direction.North);

            Assert.AreEqual(3, position.Count);
        }

        [TestMethod]
        public void ShouldGetRandomPointReturnPointInnerBordersXAndY()
        {
            Point point = Position.GetRandomPoint(Constants.MAX_X, Constants.MAX_Y);
            Assert.IsTrue(point.X <= Constants.MAX_X);
            Assert.IsTrue(point.X >= 0);

            Assert.IsTrue(point.Y <= Constants.MAX_Y);
            Assert.IsTrue(point.Y >= 0);
        }

        [TestMethod]
        public void ShouldOverflowReturnTrueWhenXorYPositionsOverflowBoard()
        {
            Point point = new Point(6, 7);
            bool case1 = Position.Overflow(point, 3, Direction.East);

            Point point2 = new Point(2, 7);
            bool case2 = Position.Overflow(point2, 2, Direction.North);

            Point point3 = new Point(2, 6);
            bool case3 = Position.Overflow(point3, 4, Direction.West);

            Point point4 = new Point(7, 1);
            bool case4 = Position.Overflow(point4, 3, Direction.South);

            Assert.IsTrue(case1);
            Assert.IsTrue(case2);
            Assert.IsTrue(case3);
            Assert.IsTrue(case4);
        }


        [TestMethod]
        public void ShouldOverflowReturnFalseWhenXorYPositionsNotOverflowBoard()
        {
            Point point = new Point(5, 6);
            bool case1 = Position.Overflow(point, 2, Direction.East);

            Point point2 = new Point(2, 7);
            bool case2 = Position.Overflow(point2, 1, Direction.North);

            Point point3 = new Point(2, 6);
            bool case3 = Position.Overflow(point3, 3, Direction.West);

            Point point4 = new Point(7, 1);
            bool case4 = Position.Overflow(point4, 2, Direction.South);

            Assert.IsFalse(case1);
            Assert.IsFalse(case2);
            Assert.IsFalse(case3);
            Assert.IsFalse(case4);
        }

    }
}
