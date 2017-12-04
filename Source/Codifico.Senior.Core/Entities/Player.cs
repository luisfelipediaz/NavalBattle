using System;
namespace Codifico.Senior.Core.Entities
{
    public class Player
    {
        public string Id { get; }

        public Boat[] Boats { get; }

        public Player(string Id)
        {
            Boats = new Boat[4];
            this.Id = Id;
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
    }
}
