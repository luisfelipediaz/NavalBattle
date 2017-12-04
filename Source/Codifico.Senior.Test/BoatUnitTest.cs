using System;
using Codifico.Senior.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Collections.Generic;

namespace Codifico.Senior.Test
{
    [TestClass]
    public class BoatUnitTest
    {
        [TestMethod]
        public void ShouldDisabledBoatWhenAllPointsAreBeaten()
        {
            Boat boat = new Boat(new Point(1, 2), new Point(1, 3));

            Point move = new Point(1, 2);
            boat.HitMarker(move);

            Point move2 = new Point(1, 3);
            boat.HitMarker(move2);

            Assert.IsFalse(boat.ItsAlive());
        }


        [TestMethod]
        public void ShouldHitMarkerReturnTrueWhenHitMarkerAssert()
        {
            Boat boat = new Boat(new Point(1, 2), new Point(1, 4));
            Boolean beaten = boat.HitMarker(new Point(1, 3));
            Assert.IsTrue(beaten);
        }

        [TestMethod]
        public void ShouldHitMarkerReturnFalseWhenHitMarkerNoAssert()
        {
            Boat boat = new Boat(new Point(1, 2), new Point(1, 4));
            Boolean beaten = boat.HitMarker(new Point(4, 2));
            Assert.IsFalse(beaten);
        }


        [TestMethod]
        public void ShouldItsAliveReturnTrueWhenAllPointsAreBeaten()
        {
            Boat boat = new Boat(new Point(1, 2), new Point(1, 3));
            boat.HitMarker(new Point(1, 2));

            Assert.IsTrue(boat.ItsAlive());
        }

        [TestMethod]
        public void ShouldItsAliveReturnFalseWhenAllPointsAreBeaten()
        {
            Boat boat = new Boat(new Point(1, 2), new Point(1, 2));
            boat.HitMarker(new Point(1, 2));

            Assert.IsFalse(boat.ItsAlive());
        }
    }
}
