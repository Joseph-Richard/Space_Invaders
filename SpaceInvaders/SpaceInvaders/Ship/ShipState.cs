using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    abstract class ShipState
    {
        public abstract void MoveRight(Ship ship);
        public abstract void MoveLeft(Ship ship);
        public abstract void Shoot(Ship ship);
        public abstract void Handle(Ship ship);
    }
}
