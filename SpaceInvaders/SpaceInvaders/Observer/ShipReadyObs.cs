using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class ShipReadyObs:Observer
    {
        public override void Notify()
        {
            Ship ship = ShipManager.getShip();
            ship.setState(ShipManager.State.Ready);
        }
    }
}
