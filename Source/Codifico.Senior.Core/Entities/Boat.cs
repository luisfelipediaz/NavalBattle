using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Codifico.Senior.Core.Tools;

namespace Codifico.Senior.Core.Entities
{
    public class Boat
    {
        Dictionary<Point, Boolean> PointsMarked { get; set; }

        public int Size { get; }

        public Boat(Point initialPoint, int size, Direction direction)
        {
            PointsMarked = Position.InitPointsNotMarked(initialPoint, size, direction);
            Size = PointsMarked.Count;
        }

        public bool HitMarker(Point move)
        {
            if (TruncatePoint(move))
            {
                PointsMarked[move] = true;
                return true;
            }

            return false;
        }

        public bool ItsAlive()
        {
            return PointsMarked.ContainsValue(false);
        }

        bool TruncatePoint(Point point)
        {
            return PointsMarked.ContainsKey(point);
        }

        public static bool TwoBoatsTruncate(Boat boat1, Boat boat2)
        {
            return boat1.PointsMarked.Any(point1 => boat2.TruncatePoint(point1.Key));
        }
    }
}
