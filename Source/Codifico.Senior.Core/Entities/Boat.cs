using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Codifico.Senior.Core.Tools;

namespace Codifico.Senior.Core.Entities
{
    public class Boat
    {
        private Dictionary<Point, Boolean> PointsMarked { get; set; }

        public Boat(Point initialPoint, Point finalPoint)
        {
            this.PointsMarked = Position.InitPointsNotMarked(initialPoint, finalPoint);
        }

        public bool HitMarker(Point move)
        {
            bool existPoint = PointsMarked.ContainsKey(move);

            if (existPoint is false)
                return false;

            return (PointsMarked[move] = true);
        }

        public bool ItsAlive()
        {
            return PointsMarked.ContainsValue(false);
        }
    }
}
