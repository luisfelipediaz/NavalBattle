using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Codifico.Senior.Core.Tools
{
    public static class Position
    {
        public static Dictionary<Point, Boolean> InitPointsNotMarked(Point pointInitial, Point pointFinal)
        {
            Dictionary<Point, Boolean> points = new Dictionary<Point, bool>();

            Point lessPoint = GetLessPoint(ref pointInitial, ref pointFinal);
            Point higherPoint = GetHigherPoint(pointInitial, pointFinal);

            for (int x = lessPoint.X; x <= higherPoint.X; x++)
            {
                for (int y = lessPoint.Y; y <= higherPoint.Y; y++)
                {
                    points.Add(new Point(x, y), false);
                }
            }

            return points;
        }

        private static Point GetHigherPoint(Point pointInitial, Point pointFinal)
        {
            if (pointInitial.X >= pointFinal.X && pointInitial.Y >= pointFinal.Y)
                return pointInitial;
            else
                return pointFinal;
        }

        private static Point GetLessPoint(ref Point pointInitial, ref Point pointFinal)
        {
            if (pointInitial.X <= pointFinal.X && pointInitial.Y <= pointFinal.Y)
                return pointInitial;
            else
                return pointFinal;
        }
    }

}
