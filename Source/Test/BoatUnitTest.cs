using Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class BoatUnitTest
    {
        [TestMethod]
        public void ShouldDisabledBoatWhenAllPointsAreBeaten()
        {
            Boat boat = new Boat(new Point(1, 2), 2, Core.Direction.North);

            Point move = new Point(1, 2);
            boat.HitMarker(move);

            Point move2 = new Point(1, 3);
            boat.HitMarker(move2);

            Assert.IsFalse(boat.ItsAlive());
        }

        [TestMethod]
        public void ShouldHitMarkerReturnTrueWhenHitMarkerAssert()
        {
            Boat boat = new Boat(new Point(1, 2), 3, Core.Direction.North);
            Boolean beaten = boat.HitMarker(new Point(1, 3));
            Assert.IsTrue(beaten);
        }

        [TestMethod]
        public void ShouldHitMarkerReturnFalseWhenHitMarkerNoAssert()
        {
            Boat boat = new Boat(new Point(1, 2), 3, Core.Direction.North);
            Boolean beaten = boat.HitMarker(new Point(4, 2));
            Assert.IsFalse(beaten);
        }


        [TestMethod]
        public void ShouldItsAliveReturnTrueWhenAllPointsAreBeaten()
        {
            Boat boat = new Boat(new Point(1, 2), 2, Core.Direction.North);
            boat.HitMarker(new Point(1, 2));

            Assert.IsTrue(boat.ItsAlive());
        }

        [TestMethod]
        public void ShouldItsAliveReturnFalseWhenAllPointsAreBeaten()
        {
            Boat boat = new Boat(new Point(1, 2), 1, Core.Direction.North);
            boat.HitMarker(new Point(1, 2));

            Assert.IsFalse(boat.ItsAlive());
        }

        [TestMethod]
        public void ShouldTwoBoatsTruncateReturnTrue()
        {
            Boat boat1 = new Boat(new Point(1, 1), 3, Core.Direction.North);
            Boat boat2 = new Boat(new Point(1, 2), 3, Core.Direction.East);
            bool actual = Boat.TwoBoatsTruncate(boat1, boat2);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldTwoBoatsTruncateReturnFalse()
        {
            Boat boat1 = new Boat(new Point(1, 1), 3, Core.Direction.North);
            Boat boat2 = new Boat(new Point(2, 2), 3, Core.Direction.East);
            bool actual = Boat.TwoBoatsTruncate(boat1, boat2);
            Assert.IsFalse(actual);
        }
    }
}
