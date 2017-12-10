using System;
using System.Drawing;

namespace Core.Entities
{
    public class PointBoat
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool Beaten { get; set; }

        public PointBoat(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.Beaten = false;
        }

        public override bool Equals(object obj)
        {
            switch(obj){
                case Point point:
                    return point.X.Equals(this.X) && point.Y.Equals(this.Y);
                
                default:
                    return false;
            }

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
