using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Codifico.Senior.Core.Tools;

namespace Codifico.Senior.Core.Entities
{
    public class Boat
    {
        public int Size { get; }

        private Dictionary<Point, Boolean> PointsMarked { get; set; }

        public Boat(Point pointInitial, Point pointFinal)
        {
            this.PointsMarked = Position.InitPointsNotMarked(pointInitial, pointFinal);
            Size = this.PointsMarked.Count();
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
