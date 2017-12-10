using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Core.Tools;

namespace Core.Entities
{
    public class Player
    {
        public string Id { get; }

        public List<Boat> Boats { get; }

        public List<PointBoat> Moves { get; }

        public Player(string Id)
        {
            Moves = new List<PointBoat>();
            Boats = new List<Boat>(Constants.BOATS_PER_PLAYER);
            this.Id = Id;
        }

        public bool AddBoat(Boat newBoat)
        {
            if (AnyBoatTruncateWithNew(newBoat))
                return false;

            Boats.Add(newBoat);
            return true;
        }

        bool AnyBoatTruncateWithNew(Boat newBoat)
        {
            return Boats.Any(baot => Boat.TwoBoatsTruncate(baot, newBoat));
        }

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case String Id:
                    return this.Id.Equals(Id);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public bool HitMarket(Point move)
        {
            return Boats.Any(boat => boat.HitMarker(move));
        }
    }
}
