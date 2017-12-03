using System;
namespace Codifico.Senior.Core.Entities
{
    public class Player
    {
        public string Id
        {
            get;
            set;
        }

        public Boat[] Boats
        {
            get;
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
