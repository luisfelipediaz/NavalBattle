using System;
using System.Collections.Generic;
using System.Drawing;

namespace Codifico.Senior.Core.Tools
{
    public static class Position
    {
        public static Dictionary<Point, Boolean> InitPointsNotMarked(Point initialPoint, int size, Direction direction)
        {
            Dictionary<Point, Boolean> points = new Dictionary<Point, bool>();

            int minX = initialPoint.X;
            int maxX = initialPoint.X;
            int minY = initialPoint.Y;
            int maxY = initialPoint.Y;

            switch (direction)
            {
                case Direction.North:
                    maxY = initialPoint.Y + GetNormalizeSize(size);
                    break;
                case Direction.South:
                    minY = initialPoint.Y - GetNormalizeSize(size);
                    break;
                case Direction.East:
                    maxX = initialPoint.X + GetNormalizeSize(size);
                    break;
                case Direction.West:
                    minX = initialPoint.X - GetNormalizeSize(size);
                    break;
            }

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    points.Add(new Point(x, y), false);
                }
            }

            return points;
        }

        public static Point GetRandomPoint(int maxX, int maxY)
        {
            Random random = new Random();
            return new Point(random.Next(0, maxX), random.Next(0, maxY));
        }

        public static Direction GetRandomDirection()
        {
            Random random = new Random();
            return (Direction)random.Next(1, 4);
        }

        public static bool Overflow(Point point, int size, Direction direction)
        {
            switch (direction)
            {
                case Direction.East:
                    return (point.X + GetNormalizeSize(size)) > Constants.MAX_X;
                case Direction.West:
                    return (point.X - GetNormalizeSize(size)) < 0;
                case Direction.North:
                    return (point.Y + GetNormalizeSize(size)) > Constants.MAX_Y;
                default:
                    return (point.Y - GetNormalizeSize(size)) < 0;
            }
        }

        public static int GetNormalizeSize(int size)
        {
            return size - 1;
        }

    }

}
