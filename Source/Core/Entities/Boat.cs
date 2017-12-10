using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Core.Tools;

namespace Core.Entities
{
    public class Boat
    {
        public List<PointBoat> Points { get; set; }

        public Direction Direction { get; set; }

        public Boat(Point initialPoint, int size, Direction direction)
        {
            Points = Position.InitPointsNotMarked(initialPoint, size, direction);
            Direction = direction;
        }

        public bool HitMarker(Point move)
        {
            if (TruncatePoint(move))
            {
                Points.ForEach(position => {
                    if(position.Equals(move)){
                        position.Beaten = true;
                    }
                });
                return true;
            }

            return false;
        }

        public bool ItsAlive()
        {
            return Points.Exists(point => !point.Beaten);
        }

        bool TruncatePoint(Point compare)
        {
            return Points
                .Exists(position => position.Equals(compare));
        }

        public static bool TwoBoatsTruncate(Boat boat1, Boat boat2)
        {
            return boat1.Points
                        .Any(point1 =>
                             boat2.TruncatePoint(new Point(point1.X, point1.Y)));
        }
    }
}
